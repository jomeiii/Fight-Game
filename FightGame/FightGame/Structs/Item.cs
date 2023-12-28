namespace FightGame.Structs
{
    public struct Item
    {
        private string _name;
        private int _cost;
        private bool _onEquiped = false;
        private ItemType _type;
        private ItemSize _size;

        public string Name => _name;
        public int Cost => _cost;
        public bool OnEquiped => _onEquiped;
        public ItemType Type => _type;
        public ItemSize Size => _size;

        public Item(string name, int cost, ItemType type, ItemSize size)
        {
            _name = name;
            _cost = cost;
            _type = type;
            _size = size;
        }

        public static void PrintListItems(List<Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine("Cost" + item._cost);
                Console.WriteLine("Name" + item._name);
                Console.WriteLine("Size" + item._size);
                Console.WriteLine("Type" + item._type);
            }
            Console.WriteLine();
        }
    }

    public enum ItemType
    {
        Weapon,
        Shield
    }

    public enum ItemSize
    {
        Small,
        Medium,
        Large
    }
}