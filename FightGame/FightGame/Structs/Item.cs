using FightGame.Scripts;

namespace FightGame.Structs
{
    public struct Item
    {
        private string _name;
        private int _cost;
        private int _protection;
        private int _protectionQuality;
        private ItemType _type;
        private ItemSize _size;
        private PlayerType _playerType;

        public string Name => _name;
        public int Cost => _cost;
        public int Protection
        {
            get => _protection;
            set => _protection = value;
        }

        public int ProtectionQuality
        {
            get => _protectionQuality;
            set => _protectionQuality = value;
        }
        public ItemType Type => _type;
        public ItemSize Size => _size;
        public PlayerType PlayerType => _playerType;


        public Item(string name, int cost, int protection, int protectionQuality, ItemType type, ItemSize size)
        {
            _name = name;
            _cost = cost;
            _protection = protection;
            _protectionQuality = protectionQuality;
            _type = type;
            _size = size;   
           
            switch (_type)
            {
                case ItemType.Shield:
                    _playerType = PlayerType.Warrior; 
                    break;
                case ItemType.Weapon:
                    _playerType = PlayerType.Shooter; 
                    break;
                case ItemType.Accessories:
                    _playerType = PlayerType.Magician;
                    break;
                default:
                    _playerType = PlayerType.Other;
                    break;
            }
        }

        public static Item GenerateItem(string name, int maxCost, int maxProtection, int maxProtectionQuality)
        {
            Random random = new();

            return new Item(name,                                                    //Имя
                random.Next(50, maxCost),                                            //Цена
                random.Next(5, maxProtection),                                       //Защита
                random.Next(10, maxProtectionQuality),                               //Качество защиты
                (ItemType)random.Next(0, Enum.GetNames(typeof(ItemSize)).Length),    //Тип
                (ItemSize)random.Next(0, Enum.GetNames(typeof(ItemSize)).Length)     //Размер
                );
        }

        public void PrintItemInfo()
        {
            Console.WriteLine($"Имя {_name} | Стоимость {_cost} | " +
                $"Защита {_protection} | Качество защиты {_protectionQuality} | " +
                $"Размер {_size} | Тип {_type}\n");
        }
    }

    public enum ItemType
    {
        Weapon,
        Shield,
        Accessories
    }

    public enum ItemSize
    {
        Small,
        Medium,
        Large
    }
}