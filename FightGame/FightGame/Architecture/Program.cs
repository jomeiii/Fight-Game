using FightGame.Scripts;
using FightGame.Structs;

namespace FightGame
{
    public class Program
    {
        static void Main()
        {
            //Настройка UI
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            

            World.SetLevels(GenerateLevels());

            Game.GameProcess();

            Console.WriteLine($"Game finish");

            // World.PrintLevels();
        }
        public static List<Level> GenerateLevels()
        {
            int count = 1;

            while (count <= 0)
            {
                Console.WriteLine("Минимально значение уровней должно быить не меньше нуля\n" +
                "Введите новое значение");
                bool parse = int.TryParse(Console.ReadLine(), out count);
                if (parse && count > 0)
                    break;
                else
                    continue;
            }

            List<Level> levels = new();
            for (int i = 0; i < count; i++)
            {
                levels.Add(new Level(i, $"Уровень {i + 1}"));
            }
            return levels;
        }
    }
}