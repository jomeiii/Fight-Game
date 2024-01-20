using FightGame.Structs;

namespace FightGame.Scripts
{
    public class Equipment
    {
        private int _smallSlots;
        private int _mediumSlots;
        private int _largeSlots;

        private int _equippedSSlots = 0;
        private int _equippedMSlots = 0;
        private int _equippedLSlots = 0;

        private List<Item> _items = new();

        public Equipment(int smallSlots, int mediumSlots, int largeSlots)
        {
            _smallSlots = smallSlots;
            _mediumSlots = mediumSlots;
            _largeSlots = largeSlots;
        }

        public void ShowEquipment()
        {
            Console.Clear();
            Console.WriteLine("������ ������� ���������");
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{i} | {_items[i].Name}: Type: {_items[i].Type} Size: {_items[i].Size} " +
                    $"| Cost: {_items[i].Cost}");
            }
        }

        public void EquipItem(Item item)
        {
            if (item.Size == ItemSize.Small && _smallSlots > _equippedSSlots)
            {
                _items.Add(item);
                _equippedSSlots += 1;
            }
            else if (item.Size == ItemSize.Medium && _mediumSlots > _equippedMSlots)
            {
                _items.Add(item);
                _equippedMSlots += 1;
            }
            else if (item.Size == ItemSize.Large && _largeSlots > _equippedLSlots)
            {
                _items.Add(item);
                _equippedLSlots += 1;
            }
        }

        public void UnequipItem(int id)
        {
            Item item = _items[id];
            switch (item.Size)
            {
                case ItemSize.Small:
                    _smallSlots += 1;
                    break;
                case ItemSize.Medium:
                    _mediumSlots += 1;
                    break;
                case ItemSize.Large:
                    _largeSlots += 1;
                    break;
            }
            _items.RemoveAt(id);
        }
    }
}