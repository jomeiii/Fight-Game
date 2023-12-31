using System.Reflection.Metadata.Ecma335;

namespace FightGame.Structs
{
    public struct Inventory
    {
        private int _protection;
        private int _protectionQuality;
        private List<Item> _items;
        public int Protection => _protection;
        public int ProtectionQuality => _protectionQuality;
        public List<Item> Items => _items;

        #region Costructors
        public Inventory()
        {
            _items = new();
            _protection = 0;
            _protectionQuality = 0;
        }
        public Inventory(List<Item> items)
        {
            _items = items;
            _protection = 0;
            _protectionQuality = 0;
            foreach (var item in items)
            {
                _protection += item.Protection;
                _protectionQuality += item.ProtectionQuality;
            }
        }
        #endregion

        public static Inventory GenerateInventory(int countItem)
        {
            Inventory inventory = new();
            for (int i = 0; i < countItem; i++)
            {
                inventory.AddItemInInventory(Item.GenerateItem($"Item {i + 1}", 100, 100, 100, 3));
            }
            return inventory;
        }

        public void AddItemInInventory(Item item)
        {
            _items.Add(item);

            _protection += item.Protection;
            _protectionQuality += item.ProtectionQuality;

            Console.WriteLine($"Protection: {_protection}");
            Console.WriteLine($"Protection Quality: {_protectionQuality}");
        }
        public void AddItemsInInvntory(List<Item> items)
        {
            foreach (var item in items)
            {
                AddItemInInventory(item);
            }
        }
        public void PrintInventory()
        {
            if (_items.Count == 0)
                Console.WriteLine("Инвентарь пуст");
            else
                foreach (Item item in _items)
                    item.PrintItemInfo();
        }
        public static void PrintInventory(Inventory inventory)
        {
            if (inventory.Items.Count == 0)
                Console.WriteLine("Инвентарь пуст");
            else
                foreach (Item item in inventory.Items)
                    item.PrintItemInfo();
        }
    }
}