namespace FightGame.Scripts.NPCs
{
    public class Boss : Enemy
    {
        public Boss(string name, int health, int damage, int missChance, Equipment equipment) : base(name, health, damage, missChance, equipment)
        {
        }

        public new void Speak()
        {
            Console.WriteLine("Я Boss");
        }
    }
}