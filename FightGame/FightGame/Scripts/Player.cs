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
            _params = new CharacterParams(name, 200, 200, 20);
            _inventory = new(new List<Item>() { new Item("New Item For Test", 500, 12, 34, ItemType.Weapon, ItemSize.Small) });
            _lifes = 3;
            _gold = 100;
            _equipment = new Equipment(4, 2, 1);
            MaxHealth = 500;
            _highestHealth = _params.Health;
        }

        public void TakeDmg(int damage)
        {
            /*
            //Применяем защиту и качество защиты к полученному урону
            int actualDamage = (int)(damage * (1 - _inventory.TotalProtection));
            int damageTaken = actualDamage - _inventory.TotalProtectionQuality;

            //Учитываем защиту и качество защиты при вычитании урона из здоровья
            if (damageTaken > 0)
            {
               _params.Health -= damageTaken;
            }*/
            _params.Health -= damage;
        }

        public void Respawn()
        {
            if (_params.Health <= 0)
            {
                if (_lifes > 0)
                {
                    _lifes -= 1;
                    Console.WriteLine($"У игрока осталось {_lifes} жизней");
                    _params.Health = _highestHealth;
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

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Восстановлено 5 здоровья");
                Console.WriteLine($"Ваше здоровье {_params.Health}");
                Console.ForegroundColor = ConsoleColor.White;

                _highestHealth = _params.Health;
            }
        }

        public void PrintStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Ваши характеристики");
            Console.WriteLine($"Имя: {_params.Name}, Здоровье: {_params.Health}, Урон: {_params.Damage}, Шанс промаха: {_params.MissChance}%");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}