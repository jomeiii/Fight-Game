using FightGame.Structs;

namespace FightGame.Scripts
{
    public class Inventory
    {
        private int _totalProtection = 0;
        private int _totalProtectionQuality = 0;
        private List<Item> _items;

        public int TotalProtection => _totalProtection;
        public int TotalProtectionQuality => _totalProtectionQuality;
        public List<Item> Items => _items;

        #region Costructors
        public Inventory()
        {
            _items = new();
        }
        public Inventory(List<Item> items)
        {
            _items = new();
            foreach (var item in items)
            {
                _items.Add(item);

                _totalProtection += item.Protection;
                _totalProtectionQuality += item.ProtectionQuality;
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

            _totalProtection += item.Protection;
            _totalProtectionQuality += item.ProtectionQuality;
        }

        public void AddItemsInInventory(List<Item> items)
        {
            foreach (Item item in items)
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