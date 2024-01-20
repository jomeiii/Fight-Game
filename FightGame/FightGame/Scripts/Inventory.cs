using FightGame.Structs;

namespace FightGame.Scripts
{
    public class Inventory
    {
        private int _totalProtection = 0;
        private int _totalProtectionQuality = 0;
        private List<Item> _items;
        private PlayerType _playerType;

        public int TotalProtection
        {
            get => _totalProtection;
            set
            {
                _totalProtection = value;
            }
        }
        public int TotalProtectionQuality
        {
            get => _totalProtectionQuality;
            set
            {
                _totalProtectionQuality = value;
            }
        }
        public List<Item> Items => _items;
        public PlayerType PlayerType => _playerType;

        #region Constructors
        public Inventory(PlayerType playerType)
        {
            _items = new();
            _playerType = playerType;
        }
        public Inventory(Item item, PlayerType playerType)
        {
            _items = new();
            _playerType = PlayerType;
            AddItemInInventory(item);
        }
        public Inventory(List<Item> items, PlayerType playerType)
        {
            _items = new();
            _playerType = PlayerType;
            AddItemsInInventory(items);
        }
        #endregion

        public static Inventory GenerateInventory(int countItem, PlayerType playerType)
        {
            Inventory inventory = new(playerType);
            PlayerType itemPlayerType;
            for (int i = 0; i < countItem; i++)
            {
                if (playerType == PlayerType.Other)
                    itemPlayerType = (PlayerType)new Random().Next(0, Enum.GetNames(typeof(PlayerType)).Length) - 1;
                else
                    itemPlayerType = playerType;

                inventory.AddItemInInventory(Item.GenerateItem($"Item {i + 1}", 250, 150, 100));
            }
            return inventory;
        }

        /// <summary>
        /// Добавление предмета в инвентарь, в том случае если тип для какого типа предназначен предмет 
        /// и тип персонажа совпадают
        /// </summary>
        /// <param name="item">Предмет, который нужно добавить в инвентарь</param>
        /// <param name="playerType">Тип персонажа</param>
        /// <returns>Успешное или не успешное добавление в инвентарь</returns>
        public bool AddItemInInventory(Item item)
        {
            if (item.PlayerType == _playerType || _playerType == PlayerType.Other)
            {
                _items.Add(item);

                _totalProtection += item.Protection;
                _totalProtectionQuality += item.ProtectionQuality;
                return true;
            }
            return false;
        }

        public void AddItemsInInventory(List<Item> items)
        {
            foreach (Item item in items)
            {
                AddItemInInventory(item);
            }
        }
        public void Print()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ваш инвентарь");
            Console.ForegroundColor = ConsoleColor.White;

            if (_items.Count == 0)
                Console.WriteLine("Инвентарь пуст");
            else
                foreach (Item item in _items)
                    item.PrintItemInfo();
        }
    }
}