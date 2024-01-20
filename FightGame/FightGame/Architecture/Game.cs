using FightGame.Scripts;

namespace FightGame
{
    public static class Game
    {
        private static Player _player;
        public static Player Player => _player;

        static Game()
        {
            _player = Player.Create();

            Console.WriteLine($"\nВаш персонаж создан!");
            _player.PrintStats();

            PressEnter();

            Init();
        }
        private static void Init()
        {
            Console.WriteLine("Game Init");
        }

        public static void GameProcess()
        {
        Menu:
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Меню\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Нажмите:\n" +
                    "1 - драться\n" +
                    "2 - открыть инвентарь\n" +
                    "3 - вывести характеристики персонажа\n" +
                    "4 - зайти в магазин");

                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        goto Battle;

                    case ConsoleKey.D2:
                        Console.WriteLine();
                        _player.Inventory.Print();
                        PressEnter();
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine();
                        _player.PrintStats();
                        PressEnter();
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine();
                        goto Shop;
                }
            }

        Battle:
            // Начало битвы с противником
            Level currentLevel = World.CurrentLvl;
            if (currentLevel != null)
            {
                Battle.BattlePVE(currentLevel.TakeFighter());
            }

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
        Shop:
            Shop.Open();
            PressEnter();
            goto Menu;

        EveryStep:
            // Ожидание нажатия клавиши для продолжения игры
            PressEnter();
            Console.Clear();

            // Добавление золота и регенерация здоровья игрока
            _player.Gold += 5;
            _player.Regeneration();
            Thread.Sleep(1500);

            if (World.CurrentLvl != null)
                goto Menu;

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
        }
        private static void PressEnter()
        {
            Console.WriteLine($"Нажмите ENTER чтобы продолжить");
            Console.ReadLine();
        }
    }

}
