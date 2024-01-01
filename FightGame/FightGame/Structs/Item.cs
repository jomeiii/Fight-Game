namespace FightGame.Structs
{
    public struct Item
    {
        private string _name;
        private int _cost;
        private int _protection;
        private int _protectionQuality;
        private bool _onEquiped = false;
        private ItemType _type;
        private ItemSize _size;

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
        public bool OnEquiped => _onEquiped;
        public ItemType Type => _type;
        public ItemSize Size => _size;

        public Item(string name, int cost, int protection, int protectionQuality, ItemType type, ItemSize size)
        {
            _name = name;
            _cost = cost;
            _protection = protection;
            _protectionQuality = protectionQuality;
            _type = type;
            _size = size;
        }

        public static Item GenerateItem(string name, int cost, int protection, int protectionQuality, int spread)
        {
            Random rand = new();
            //* Генерация числа 
            int GenerateNumber(int number)
            {
                if (spread == 0 && spread < 0)
                    return number;

                int minNum = cost - (int)(cost * 0.2);
                int maxNum = cost + (int)(cost * 0.2);
                return rand.Next(minNum, maxNum);
            }

            //* Генерация случайного типа
            ItemType GenerateItemType()
            {
                switch (rand.Next(Enum.GetNames(typeof(ItemType)).Length))
                {
                    case 0:
                        return ItemType.Weapon;
                    case 1:
                        return ItemType.Shield;
                    case 2:
                        return ItemType.Accessories;
                    default:
                        return ItemType.Weapon;
                }
            }

            //* Генерация случайного размера
            ItemSize GenerateItemSize()
            {
                switch (rand.Next(Enum.GetNames(typeof(ItemSize)).Length))
                {
                    case 0:
                        return ItemSize.Small;
                    case 1:
                        return ItemSize.Medium;
                    case 2:
                        return ItemSize.Large;
                    default:
                        return ItemSize.Small;
                }
            }

            return new Item(name, GenerateNumber(cost), GenerateNumber(protection),
            GenerateNumber(protectionQuality), GenerateItemType(), GenerateItemSize());
        }

        public void PrintItemInfo()
        {
            Console.WriteLine("Name " + _name);
            Console.WriteLine("Cost " + _cost);
            Console.WriteLine("Protection " + _protection);
            Console.WriteLine("Protection Quality " + _protectionQuality);
            Console.WriteLine("Size " + _size);
            Console.WriteLine("Type " + _type);
            Console.WriteLine();
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