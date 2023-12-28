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
        public static Level CurrentLvl
        {
            get
            {
                {
                    if (!_levels[_currentLvl].Finished)
                        return _levels[_currentLvl];
                    else
                    {
                        _currentLvl += 1;
                        return _levels[_currentLvl];
                    }
                }
            }
        }

        public static void SetLevels(List<Level> levels)
        {
            _levels = levels;
        }
        public static void PrintLevels()
        {
            foreach (var i in _levels)
            {
                Console.WriteLine("ID " + i.Id);
                Console.WriteLine("Name " + i.Name);
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
        public bool Finished => _npcs.Count <= 0;

        public Level(int id, string name)
        {
            _id = id;
            _name = name;
            _npcs = new List<NPC>();
            NPCGenerator();
        }
        private void NPCGenerator()
        {
            for (int i = 0; i < 3; i++)
            {
                _npcs.Add(new Enemy($"NPC {i}", 100, 10, new Equipment(2, 1, 1)));
            }
        }

        //TODO: переделавть под NPC
        public IBattler TakeFighter()
        {
            IBattler fighter = _npcs[0];
            _npcs.RemoveAt(0);
            return fighter;
        }
    }
}