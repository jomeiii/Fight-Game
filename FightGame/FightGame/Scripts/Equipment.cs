using FightGame.Structs;

namespace FightGame.Scripts
{
    public class Equipment
    {
        private int _smallSlots;
        private int _mediumSlots;
        private int _largeSlots;

        private List<Item> _items = new();

        public Equipment(int smallSlots, int mediumSlots, int largeSlots)
        {
            _smallSlots = smallSlots;
            _mediumSlots = mediumSlots;
            _largeSlots = largeSlots;
        }

        public void AddItem(Item item)
        {
            if (item.Size == ItemSize.Small && _smallSlots > 0)
            {
                _items.Add(item);
                _smallSlots -= 1;
            }
            else if (item.Size == ItemSize.Medium && _mediumSlots > 0)
            {
                _items.Add(item);
                _mediumSlots -= 1;
            }
            else if (item.Size == ItemSize.Large && _largeSlots > 0)
            {
                _items.Add(item);
                _largeSlots -= 1;
            }
        }


    }
}