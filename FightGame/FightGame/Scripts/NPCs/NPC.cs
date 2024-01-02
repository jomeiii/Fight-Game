using FightGame.Interfaces;
using FightGame.Structs;

namespace FightGame.Scripts.NPCs
{
    public abstract class NPC : IBattler
    {
        protected CharacterParams _params;

        public NPC(string name, int health, int damage, int missChance)
        {
            _params = new CharacterParams(name, health, damage, missChance);
        }

        public CharacterParams Params => _params;

        public virtual void Speak()
        {
            Console.WriteLine("Я NPC");
        }

        public void TakeDmg(int dmg)
        {
            _params.Health -= dmg;
        }

        public void PrintStats()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\nХарактеристики противника");
            Console.WriteLine($"Имя: {_params.Name}, Здоровье: {_params.Health}, Урон: {_params.Damage}, Шанс промаха: {_params.MissChance}%\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}