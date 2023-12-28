using System.Xml;
using FightGame.Scripts;
using FightGame.Scripts.NPCs;
using FightGame.Structs;

namespace FightGame
{
    public static class Game
    {
        private static Player _player;

        public static Player Player => _player;

        static Game()
        {
            _player = new Player("Stepa");
            Init();
        }
        private static void Init()
        {
            System.Console.WriteLine("Game Init");
        }
    
        public static void GameProcess()
        {
        Batlle:
            Battle.BattlePVE(World.CurrentLvl.TakeFighter());
            if (_player.Params.Health <= 0 && _player.Lifes <= 0)
                goto GameOver;
            else
            {
                if (_player.Params.Health <= 0)
                    _player.Respawn();

                Console.WriteLine("Нажмите ENTER для продолжения игры");
                Console.ReadLine();
                // Console.Clear();
                goto EveryStep;
            }

        EveryStep:
            _player.Gold += 5;
            _player.Regeneration();
            goto Batlle;

        GameOver:
            Console.WriteLine("Game over");
            Console.ReadLine();
        }
    }
}