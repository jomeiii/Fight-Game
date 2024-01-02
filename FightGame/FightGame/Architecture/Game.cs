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
            Console.WriteLine($"Ваш персонаж создан!");
            _player.PrintStats();

            Console.WriteLine($"Нажмите ENTER чтобы продолжить");
            Console.ReadLine();

            // Shop.OpenShop();

            Item item = new("Новый предмет", 10000, 456, 987, ItemType.Weapon, ItemSize.Large);

            _player.Inventory.PrintInventory();
            Console.WriteLine();

            _player.Inventory.AddItemInInventory(item);

            _player.Inventory.PrintInventory();

            Console.WriteLine($"Protection { _player.Inventory.TotalProtection}");
            Console.WriteLine($"ProtectionQuality { _player.Inventory.TotalProtectionQuality}");

            Init();
        }
        private static void Init()
        {
            Console.WriteLine("Game Init");
        }

        public static void GameProcess()
        {
            while (true)
            {
            Battle:
                // Начало битвы с противником
                Battle.BattlePVE(World.CurrentLvl.TakeFighter());

                // Проверка состояния игрока после битвы
                if (_player.Params.Health <= 0 && _player.Lifes <= 0)
                    goto GameOver;
                else
                {
                    if (_player.Params.Health <= 0)
                    {
                        // Игрок мертв, возрождение и проверка количества жизней
                        _player.Respawn();
                        if (_player.Lifes <= 0)
                        {
                            goto GameOver;
                        }
                    }
                    goto EveryStep;
                }

            EveryStep:
                // Ожидание нажатия клавиши для продолжения игры
                Console.WriteLine("Нажмите ENTER для продолжения игры");
                Console.ReadLine();
                Console.Clear();

                // Добавление золота и регенерация здоровья игрока
                _player.Gold += 5;
                _player.Regeneration();

                if (World.CurrentLvl != null)
                    goto Battle;
                else
                {
                    Console.WriteLine("Вы прошли все уровни");
                    Console.WriteLine("Создать новые уровни?");
                    Console.WriteLine("1) Да\n2) Нет");
                    while (true)
                    {
                        string? inputString = Console.ReadLine();
                        if (inputString == "1")
                        {
                            World.SetLevels(Program.GenerateLevels());
                            goto Battle;
                        }
                        else if (inputString == "2")
                        {
                            goto GameOver;
                        }
                        else
                        {
                            Console.WriteLine("Введен некорректный формат числа. Попробуйте еще раз!");
                        }
                    }
                }
            GameOver:
                // Конец игры
                Console.WriteLine("Игра закончена");


                Console.ReadLine();
                break;
            }
        }
    }
}