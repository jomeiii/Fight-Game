namespace FightGame.Scripts
{
    public static class PlayerMovement
    {
        private static Random random = new();
        private static Player _player = Game.Player;

        // Settings
        private static int _mapSizeX = 10; // Ширина карты
        private static int _mapSizeY = 5; // Высота карты
        private static char[,] _bg = new char[_mapSizeY, _mapSizeX]; // Массив для хранения карты

        //Gold
        private static int _goldCount = 3;

        //Input
        private static ConsoleKey _input; // Переменная для хранения ввода пользователя

        //Flag
        private static bool _isFinished; // Флаг завершения игры

        public static int MapSizeX
        {
            get => _mapSizeX;
            set { if (value > 0) _mapSizeX = value; }
        }
        public static int MapSizeY
        {
            get => _mapSizeY;
            set { if (value > 0) _mapSizeY = value; }
        }
        public static int CountGold
        {
            get => _goldCount;
            set { if (value > 0) _goldCount = value; }
        }

        static PlayerMovement()
        {
            //* Генерация пустого фона
            for (int y = 0; y < _mapSizeY; y++)
                for (int x = 0; x < _mapSizeX; x++)
                    _bg[y, x] = '-';
            _bg[_player.PosY, _player.PosX] = 'P';
            GenerateCoinPositions();
            _bg[3, 3] = 'S';
        }


        /// <summary>
        /// Метод для обработки движения игрока
        /// </summary>
        public static void Movement()
        {
            Console.BackgroundColor = ConsoleColor.Black; // Задаем цвет фона консоли
            Console.Clear(); // Очищаем консоль

            PrintMap();

            while (!_isFinished)
            {
                _input = Console.ReadKey().Key; // Считываем ввод пользователя
                Console.Clear(); // Очищаем консоль
                switch (_input)
                {
                    case ConsoleKey.W: // Движение вверх
                        GoUp();
                        break;
                    case ConsoleKey.S: // Движение вниз
                        GoDown();
                        break;
                    case ConsoleKey.A: // Движение влево
                        GoLeft();
                        break;
                    case ConsoleKey.D: // Движение вправо
                        GoRight();
                        break;
                    case ConsoleKey.Spacebar: // Завершение игры
                        _isFinished = true;
                        break;
                }
                PrintMap();
            }
        }

        #region PlayerMovementMethod
        private static void UpdatePlayerPosition(int newY, int newX)
        {
            _player.LastPosY = _player.PosY;
            _player.LastPosX = _player.PosX;

            _player.PosY = newY;
            _player.PosX = newX;

            switch (_bg[newY, newX])
            {
                case 'G':
                    _player.Gold += 5;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(_player.Gold);
                    break;
                case 'S':
                    Shop.Open();
                    break;
                default:
                    break;
            }
            _bg[_player.PosY, _player.PosX] = 'P';
            _bg[_player.LastPosY, _player.LastPosX] = '-';
        }

        #region Go...

        private static void GoUp()
        {
            if (_player.PosY > 0)
            {
                UpdatePlayerPosition(_player.PosY - 1, _player.PosX);
            }
        }

        private static void GoDown()
        {
            if (_player.PosY < _mapSizeY - 1)
            {
                UpdatePlayerPosition(_player.PosY + 1, _player.PosX);
            }
        }

        private static void GoRight()
        {
            if (_player.PosX < _mapSizeX - 1)
            {
                UpdatePlayerPosition(_player.PosY, _player.PosX + 1);
            }
        }

        private static void GoLeft()
        {
            if (_player.PosX > 0)
            {
                UpdatePlayerPosition(_player.PosY, _player.PosX - 1);
            }
        }
        #endregion

        #endregion

        private static void PrintMap()
        {
            for (int y = -1; y <= _mapSizeY; y++)
            {
                for (int x = -1; x <= _mapSizeX; x++)
                {
                    char i = ' ';
                    if (y == -1 || y == _mapSizeY || x == -1 || x == _mapSizeX)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        i = _bg[y, x];
                        switch (i)
                        {
                            case 'P':
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 'G':
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 'S':
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                break;
                        }
                        Console.Write(i); // Отображаем символ
                    }
                }
                Console.WriteLine();
            }
        }
        private static void GenerateCoinPositions()
        {
            int coinsGeneratedCount = 0;
            while (coinsGeneratedCount < _goldCount) // Число 3 - количество золотых символов, которые нужно добавить
            {
                int x = random.Next(1, _mapSizeX - 1); // Генерация случайной координаты X
                int y = random.Next(1, _mapSizeY - 1); // Генерация случайной координаты Y

                if (_bg[y, x] == '-') // Проверка, что клетка пустая
                {
                    _bg[y, x] = 'G'; // Замена символа на 'G'
                    coinsGeneratedCount++;
                }
            }
        }
    }
}