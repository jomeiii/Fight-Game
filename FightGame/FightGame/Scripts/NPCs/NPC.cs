using FightGame.Interfaces;
using FightGame.Structs;

namespace FightGame.Scripts.NPCs
{
    public abstract class NPC : IBattler
    {
        protected CharacterParams _params;

        public NPC(string name, int health, int damage)
        {
            _params = new CharacterParams(name,health,damage);
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
    }
}