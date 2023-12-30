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

            Console.WriteLine("Выберите придмет");

            Inventory.PrintInvenntory(shopGenerateInventory);

            // var inputString = string.Empty;

            // while (!string.IsNullOrEmpty(inputString))
            // {
            //     Console.WriteLine($"Select Item");
            //     inputString = Console.ReadLine();
            // }

            _player.Inventory.PrintInvenntory();
            _player.Inventory.AddItemInInvntory(shopGenerateInventory.Items[0]);
            _player.Inventory.PrintInvenntory();
            

            
        }
    }
}