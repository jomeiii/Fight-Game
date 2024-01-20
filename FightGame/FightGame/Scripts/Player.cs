using FightGame.Interfaces;
using FightGame.Structs;

namespace FightGame.Scripts
{
    public class Player : IBattler
    {
        public const int MinHealth = 1;
        public readonly int MaxHealth;

        private string _name;
        private PlayerType _type;
        private int _lifes;
        private CharacterParams _params;

        private int _gold;
        private Inventory _inventory;
        private Equipment _equipment;
        private int _highestHealth;

        public int PosX;
        public int PosY;
        public int LastPosX;
        public int LastPosY;

        public string Name => _name;
        public PlayerType Type => _type;
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
        public int Protection => _inventory.TotalProtection;
        public int ProtectionQuality => _inventory.TotalProtectionQuality;

        public Player(string name, PlayerType playerType)
        {
            _name = name;
            _type = playerType;

            switch (_type)
            {
                // Воин
                case PlayerType.Warrior:
                    _params = new CharacterParams(300, 50, 15);
                    break;
                // Стрелок
                case PlayerType.Shooter:
                    _params = new CharacterParams(150, 100, 10);
                    break;
                // Маг
                case PlayerType.Magician:
                    _params = new CharacterParams(100, 150, 25);
                    break;
                // Не обработан
                default:
                    Console.WriteLine("Тип персонажа не обработан!");
                    _params = new CharacterParams(200, 50, 20);
                    break;
            }

            _inventory = new(_type);
            _lifes = 3;
            _gold = 500;
            _equipment = new Equipment(4, 2, 1);

            MaxHealth = 500;
            _highestHealth = _params.Health;
        }

        public void TakeDmg(int damage)
        {
            if (_inventory.TotalProtection > 0)
            {
                _inventory.TotalProtection -= damage * _inventory.TotalProtectionQuality / 100;
                damage -= damage * _inventory.TotalProtectionQuality / 100;
                if (_inventory.TotalProtectionQuality < 0)
                    damage += _inventory.TotalProtectionQuality * -1;
            }

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
                _params.Health += 50;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Восстановлено 5 здоровья");
                Console.WriteLine($"Ваше здоровье {_params.Health}");
                Console.ForegroundColor = ConsoleColor.White;

                _highestHealth = _params.Health;
            }
        }

        public void PrintStats()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Ваши характеристики");
            Console.WriteLine($"Имя: {Name}, Здоровье: {_params.Health}, Урон: {_params.Damage}, " +
                $"Защита {_inventory.TotalProtection}, Качество защиты {_inventory.TotalProtectionQuality}, " +
                $"Шанс промаха: {_params.MissChance}%, Тип: {_type}\n");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static Player Create()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Создание персонажа\n");
            Console.ForegroundColor = ConsoleColor.White;

            string? name;
            do
            {
                Console.WriteLine("Введите имя:");
                name = Console.ReadLine();

            } while (string.IsNullOrEmpty(name));

            PlayerType playerType;
            int playerTypeId;
            Console.WriteLine("\nВыберите тип персонажа:\n1 - Воин\n2 - Стрелок\n3 - Маг");
            while (!int.TryParse(Console.ReadLine(), out playerTypeId) || playerTypeId < 1 || playerTypeId > 3)
            {
                Console.WriteLine("Такого типа персонажа нет! Попробуйте еще раз.");
            }
            playerTypeId -= 1;
            playerType = (PlayerType)playerTypeId;

            return new Player(name, playerType);
        }
    }

    public enum PlayerType
    {
        Warrior,
        Shooter,
        Magician,
        Other
    }
}