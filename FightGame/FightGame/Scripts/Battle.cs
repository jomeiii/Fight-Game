using System.Runtime.CompilerServices;
using FightGame.Interfaces;
using FightGame.Scripts.NPCs;

namespace FightGame.Scripts
{
    public static class Battle
    {
        private static Random random = new Random();
        private const int attackDelay = 1500;
        private const int deathDelay = 2000;

        /// <summary>
        /// Метод для проведения битвы между игроком и противником
        /// </summary>
        /// <param name="enemy">Противник</param>
        public static void BattlePVE(IBattler enemy)
        {
            IBattler player = Game.Player;

            // Вывод информации о противнике
            PrintEnemyStats(enemy);

            while (player.Health > 0 && enemy.Health > 0)
            {
                // Выполнение атаки игроком
                PerformAttack(player, enemy);
                Console.WriteLine();

                if (enemy.Health > 0)
                {
                    // Выполнение атаки противника
                    PerformAttack(enemy, player);
                    Console.WriteLine();
                }
            }

            if (player.Health <= 0)
            {
                // Если игрок умер
                Console.WriteLine("Игрок мертв");
                Thread.Sleep(deathDelay);
            }
            else
            {
                // Если противник умер
                Console.WriteLine("Противник мертв");
                Game.Player.Gold += 10;
                Thread.Sleep(deathDelay);
            }
        }

        // Метод для выполнения атаки
        private static void PerformAttack(IBattler attacker, IBattler target)
        {
            // Проверка шанса промаха
            if (attacker.Params.MissChance <= random.Next(0, 100))
            {
                int damage = attacker.Damage;
                target.TakeDmg(damage);

                Console.WriteLine($"{attacker.Name} нанес {damage} урона и оставил {target.Name} {(target.Health > 0 ? target.Health : 0)} здоровья");
            }
            else
            {
                Console.WriteLine($"{attacker.Name} промахнулся");
            }

            Thread.Sleep(attackDelay);
        }

        // Метод для вывода статистики противника
        private static void PrintEnemyStats(IBattler enemy) => ((NPC)enemy).PrintStats();
    }
}