namespace FightGame.Scripts.NPCs
{
    public class Boss : Enemy
    {
        public Boss(string name, int health, int damage, Equipment equipment) : base(name, health, damage, equipment)
        {
        }

        public new void Speak()
        {
            Console.WriteLine("Я Boss");
        }
    }
}