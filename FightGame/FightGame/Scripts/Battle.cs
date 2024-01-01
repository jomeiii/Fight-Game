using System.Runtime.CompilerServices;
using FightGame.Interfaces;
using FightGame.Scripts.NPCs;

namespace FightGame.Scripts
{
    public static class Battle
    {
        // Генерация случайного числа
        private static Random random = new Random();
        private static int chanceToHit; // Шанс попадания от 0 до 100
        public static void BattlePVE(IBattler enemy)
        {
            IBattler player = Game.Player;
            int playerDmg = player.Damage;

            ((NPC)enemy).PrintStats();

            while (true)
            {
                chanceToHit = random.Next(0, 100);

                if (player.Health > 0)
                {
                    if (player.Params.MissChance <= chanceToHit)
                    {
                        enemy.TakeDmg(playerDmg);
                        Console.WriteLine($"Игрок нанес {playerDmg} урона и оставил противнику {enemy.Health} здоровья");
                    }
                    else
                    {
                        Console.WriteLine($"Вы промахнулись");
                    }
                }
                else
                {
                    Console.WriteLine("Игрок мертв");
                    Thread.Sleep(2000);
                    break;
                }


                if (enemy.Health > 0)
                {
                    Console.WriteLine($"enemy.Params.MissChance {enemy.Params.MissChance}");
                    
                    Console.WriteLine($"chanceToHit {chanceToHit}");
                    
                    chanceToHit = random.Next(0, 100);
                    if (enemy.Params.MissChance <= chanceToHit)
                    {
                        player.TakeDmg(enemy.Damage);
                        Console.WriteLine($"Противнику нанес {enemy.Damage} урона и оставил игроку {player.Health} здоровья");
                    }
                    else
                    {
                        Console.WriteLine($"Противник промахнулся");
                    }
                }
                else
                {
                    Console.WriteLine("Противник мертв");
                    Game.Player.Gold += 10;
                    Thread.Sleep(2000);
                    break;
                }


                Thread.Sleep(1500);
                //Console.Clear();
            }
        }
    }
}