namespace FightGame.Scripts.NPCs
{
    public class Boss : Enemy
    {
        public Boss(string name, int health, int damage, int missChance, Inventory inventory, Equipment equipment) : base(name, health, damage, missChance, inventory, equipment)
        {
        }

        public override void Speak()
        {
            Console.WriteLine("Я Boss");
        }
    }

}