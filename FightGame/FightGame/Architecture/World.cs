using FightGame.Interfaces;
using FightGame.Scripts;
using FightGame.Scripts.NPCs;

namespace FightGame
{
    public static class World
    {
        private static List<Level> _levels = new();
        private static int _currentLvl = 0;
        public static List<Level> Levels => _levels;
        public static Level? CurrentLvl
        {
            get
            {
                if (_currentLvl < _levels.Count)
                {
                    if (!_levels[_currentLvl].IsFinished)
                    {
                        return _levels[_currentLvl];
                    }
                    else
                    {
                        _currentLvl += 1;
                        if (_currentLvl < _levels.Count)
                        {
                            return _levels[_currentLvl];
                        }
                    }
                }
                return null;
            }
        }

        public static void SetLevels(List<Level> levels)
        {
            _currentLvl = 0;
            _levels = levels;
        }
        public static void PrintLevels()
        {
            foreach (var i in _levels)
            {
                Console.WriteLine("ID " + i.Id);
                Console.WriteLine("_name " + i.Name);
            }
        }
    }

    public sealed class Level
    {
        private int _id;
        private string _name;
        private List<NPC> _npcs;

        public int Id => _id;
        public string Name => _name;
        public bool IsFinished => _npcs.Count <= 0;

        public Level(int id, string name)
        {
            _id = id;
            _name = name;
            _npcs = new List<NPC>();
            NPCGenerator();
        }
        private void NPCGenerator()
        {
            Random random = new Random();

            for (int i = 0; i < 1; i++)
            {
                _npcs.Add(new Enemy($"NPC_{i}", random.Next(0, 50), random.Next(10, 50),
                 random.Next(0, 20), Inventory.GenerateInventory(1, PlayerType.Magician), new Equipment(2, 1, 1)));

                //Inventory.GenerateInventory(1)
            }
        }

        public IBattler TakeFighter()

        {
            IBattler fighter = _npcs[0];
            _npcs.RemoveAt(0);
            return fighter;
        }
    }
}