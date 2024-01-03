
namespace FightGame.Scripts.NPCs
{
    public class Enemy : NPC
    {
        private Equipment _equipment;
        public Enemy(string name, int health, int damage, int missChance, Inventory inventory, Equipment equipment) : base(name, health, damage, missChance, inventory)
        {
            _equipment = equipment;
        }

        public override void Speak()
        {
            Console.WriteLine("Я Enemy");
        }
    }
}