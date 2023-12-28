using System.Runtime.CompilerServices;
using FightGame.Interfaces;
using FightGame.Scripts.NPCs;

namespace FightGame.Scripts
{
    public static class Battle
    {
        public static void BattlePVE(IBattler enemy)
        {
            IBattler player = Game.Player;

            while (true)
            {
                int playerDmg = 0;

                if (player.Health > 0)
                {
                    playerDmg = player.Damage;
                    enemy.TakeDmg(playerDmg);
                }
                else
                {
                    Console.WriteLine("Игрок мертв");
                    Thread.Sleep(2000);
                    break;
                }

                Console.WriteLine($"Игрок нанес {playerDmg} урона и оставил противнику {enemy.Health} здоровья");

                if (enemy.Health > 0)
                    player.TakeDmg(enemy.Damage);
                else
                {
                    Console.WriteLine("Противник мертв");
                    Game.Player.Gold += 10;
                    Thread.Sleep(2000);
                    break;
                }

                Console.WriteLine($"Противнику нанес {enemy.Damage} урона и оставил игроку {player.Health} здоровья");
                Thread.Sleep(1500);
                // Console.Clear();
            }
        }
    }
}