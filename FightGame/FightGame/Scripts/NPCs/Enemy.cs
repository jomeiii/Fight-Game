using FightGame.Interfaces;

namespace FightGame.Scripts.NPCs
{
    public class Enemy : NPC
    {
        private Equipment _equipment;
        public Enemy(string name, int health, int damage, Equipment equipment) : base(name, health, damage)
        {
            _equipment = equipment;
        }

        public override  void Speak()
        {
            Console.WriteLine("Я Enemy");
        }
    }
}