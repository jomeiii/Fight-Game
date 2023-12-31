using FightGame.Interfaces;
using FightGame.Structs;

namespace FightGame.Scripts
{
    public class Player : IBattler
    {
        public const int MinHealth = 1;
        public readonly int MaxHealth;

        private int _lifes;
        private CharacterParams _params;

        private int _gold;
        private Inventory _inventory;
        private Equipment _equipment;
        private int _highestHealth;


        public int Lifes => _lifes;
        public CharacterParams Params => _params;
        public Inventory Inventory => _inventory;

        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
            }
        }
        public Equipment Equipment => _equipment;
        public int HighestHealth => _highestHealth;


        public Player(string name)
        {
            _params = new CharacterParams(name, 200, 50);
            _inventory = new();
            _lifes = 3;
            _gold = 100;
            _equipment = new Equipment(4, 2, 1);
            MaxHealth = 500;
            _highestHealth = _params.Health;
        }

        public void TakeDmg(int damage)
        {
            //! Применяем защиту и качество защиты к полученному урону
            int actualDamage = (int)(damage * (1 - _inventory.Protection));
            int damageTaken = actualDamage - _inventory.ProtectionQuality;

            //! Учитываем защиту и качество защиты при вычитании урона из здоровья
            if (damageTaken > 0)
            {
                _params.Health -= damageTaken;
            }
        }

        public void Respawn()
        {
            if (_params.Health <= 0)
            {
                if (_lifes > 0)
                {
                    Console.WriteLine($"У игрока осталось {_lifes} жизней");
                    _params.Health = _highestHealth;
                    _lifes -= 1;
                }
                else
                {
                    Console.WriteLine("У игрока не осталось жизней");
                }
            }
            else
            {
                Console.WriteLine("Игрок еще жив");
            }
        }
        public void Regeneration()
        {
            if (_params.Health < MaxHealth)
            {
                _params.Health += 5;
                _highestHealth = _params.Health;
            }
        }
    }
}