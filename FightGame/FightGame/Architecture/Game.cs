using FightGame.Scripts;
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

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Персонаж создан!");
            Console.WriteLine($"Имя: {_player.Params.Name}, Здоровье: {_player.Params.Health}, Урон: {_player.Params.Damage}, Шанс промаха: {_player.Params.MissChance}%");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Нажмите ENTER чтобы продолжить");
            Console.ReadLine();

            // Shop.OpenShop();

            /*Item item = new("Новый предмет", 10000, 456, 987, ItemType.Weapon, ItemSize.Large);
            

            _player.Inventory.PrintInventory();
            Console.WriteLine();

            _player.Inventory.AddItemInInventory(item);

            _player.Inventory.PrintInventory();
            Console.WriteLine();*/

            //Console.WriteLine($"Protection { _player.Inventory.TotalProtection}");
            //.WriteLine($"ProtectionQuality { _player.Inventory.TotalProtectionQuality}");

            Init();
        }
        private static void Init()
        {
            Console.WriteLine("Game Init");
            Console.WriteLine();
        }

        public static void GameProcess()
        {
            while (World.CurrentLvl.Id <= World.Levels.Count - 1)
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
                    Console.Clear();
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
}