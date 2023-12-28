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
        private List<Item> _inventory = new();
        private Equipment _equipment;
        private int _originalHealth;


        public int Lifes => _lifes;
        public CharacterParams Params => _params;
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
            }
        }
        public int OriginalHealth => _originalHealth;
        

        public Player(string name)
        {
            _params = new CharacterParams(name, 200, 50);
            _lifes = 3;
            _gold = 100;
            _equipment = new Equipment(4, 2, 1);
            MaxHealth = 500;
            _originalHealth = _params.Health;
        }

        public void TakeDmg(int damage)
        {
            _params.Health -= damage;
            _originalHealth = _params.Health;
        }

        public void Respawn()
        {
            if (_params.Health <= 0)
            {
                if (_lifes > 0)
                {
                    Console.WriteLine($"У игрока осталось {_lifes} жизней");
                    _params.Health = _originalHealth;
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
            if (_params.Health < MaxHealth){
                _params.Health += 5;
                _originalHealth = _params.Health;
            }
        }
    }
}