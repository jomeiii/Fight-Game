using FightGame.Structs;

namespace FightGame.Scripts
{
    public static class Shop
    {
        private static Player _player = Game.Player;

        public static void Open()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Магазин");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Ваше золото {_player.Gold}\n");
            Console.ForegroundColor = ConsoleColor.White;

            var shopGenerateInventory = Inventory.GenerateInventory(3, PlayerType.Other);

            Console.WriteLine("Выберите предмет");
            shopGenerateInventory.Print();
            Console.WriteLine("Введите имя предмета или Z для выхода");

            bool isSelectItem = false;
            var result = 0;
            while (!isSelectItem)
            {
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && input.ToLower() == "z")
                    break;

                if (!int.TryParse(input, out result) || result < 0)
                {
                    Console.WriteLine("Введен некорректный формат числа. Попробуйте еще раз!");
                    continue;
                }

                if (shopGenerateInventory.Items.Count == 0)
                {
                    Console.WriteLine("Список предметов пуст!");
                    continue;
                }

                if (result > shopGenerateInventory.Items.Count)
                {
                    Console.WriteLine("Этого предмета нет в списке");
                }
                else
                {
                    isSelectItem = true;
                }
            }
            if (isSelectItem)
            {
                var selectItem = shopGenerateInventory.Items[result - 1];

                BuyItem(selectItem);
            }

        }
        private static void BuyItem(Item selectItem)
        {
            if (_player.Gold >= selectItem.Cost)
            {
                if (_player.Inventory.AddItemInInventory(selectItem))
                {
                    _player.Gold -= selectItem.Cost;
                    Console.WriteLine($"У вас осталось золота: {_player.Gold}\n");
                    Thread.Sleep(1000);
                    _player.Inventory.Print();
                }
                else
                {
                    ErrorBuy();
                }
            }
            else
            {
                Console.WriteLine($"У вас нехватает денег");
                Thread.Sleep(1000);
                Console.WriteLine($"У вас {_player.Gold}, а предмет стоит {selectItem.Cost}");
                Thread.Sleep(1000);
                Console.WriteLine($"Вам нужно накопить {selectItem.Cost - _player.Gold} золота\n");
            }
        }

        private static void ErrorBuy() => Console.WriteLine("Этот предмет нельзя купить для вашего типа персонажа");
    }
}