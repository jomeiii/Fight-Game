using System.Diagnostics;
using FightGame.Structs;

namespace FightGame.Scripts
{
    public static class Shop
    {
        private static Player _player = Game.Player;

        private static List<Item> _shopItems = new();

        public static void OpenShop()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Магазин");
            Console.ForegroundColor = ConsoleColor.White;

            var shopGenerateInventory = Inventory.GenerateInventory(3);

            Console.WriteLine("Выберите предмет");
            Inventory.PrintInventory(shopGenerateInventory);
            Console.WriteLine("Введите имя предмета");

            var result = 0;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out result) || result < 0)
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
                    break;
                }
            }

            Console.WriteLine(_player.Inventory.Protection);
            Console.WriteLine(_player.Inventory.ProtectionQuality);

            var selectItem = shopGenerateInventory.Items[result - 1];

            Console.WriteLine(selectItem.Protection);
            Console.WriteLine(selectItem.ProtectionQuality);

            

            if (_player.Gold >= selectItem.Cost)
            {
                _player.Gold -= selectItem.Cost;
                _player.Inventory.AddItemInInventory(selectItem);
                Console.WriteLine($"У вас осталось золота {_player.Gold}\n");
                //Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ваш инвентарь");
                Console.ForegroundColor = ConsoleColor.White;
                _player.Inventory.PrintInventory();
            }
            else
            {
                Console.WriteLine($"У вас нехватает денег");
                //Thread.Sleep(1000);
                Console.WriteLine($"У вас {_player.Gold}, а предмет стоит {selectItem.Cost}");
                //Thread.Sleep(1000);
                Console.WriteLine($"Вам нужно накопить {selectItem.Cost - _player.Gold} золота\n");
            }

            Console.WriteLine(_player.Inventory.Protection);
            Console.WriteLine(_player.Inventory.ProtectionQuality);

        }
    }
}