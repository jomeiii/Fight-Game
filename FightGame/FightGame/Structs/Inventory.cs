using System.Reflection.Metadata.Ecma335;

namespace FightGame.Structs
{
    public struct Inventory
    {
        private List<Item> _items;

        public List<Item> Items => _items;

        public Inventory()
        {
            _items = new();
        }
        public Inventory(List<Item> items)
        {
            _items = items;
        }

        public static Inventory GenerateInventory(int countItem)
        {
            Inventory inventory = new();
            for (int i = 0; i < countItem; i++)
            {
                inventory.AddItemInInvntory(Item.GenerateItem($"Item {i + 1}", 100, 100, 100, 3));
            }
            return inventory;
        }

        public void AddItemInInvntory(Item item) => _items.Add(item);

        public void AddItemsInInvntory(List<Item> items)
        {
            foreach (var item in items)
            {
                _items.Add(item);
            }
        }

        public void PrintInvenntory()
        {
            if (_items.Count == 0)
                Console.WriteLine("Инвентарь пуст");
            else
                foreach (Item item in _items)
                    item.PrintItemInfo();
        }
        public static void PrintInvenntory(Inventory inventory)
        {
            if (inventory.Items.Count == 0)
                Console.WriteLine("Инвентарь пуст");
            else
                foreach (Item item in inventory.Items)
                    item.PrintItemInfo();
        }
    }
}
