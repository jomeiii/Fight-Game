using FightGame.Structs;

namespace FightGame.Interfaces
{
    public interface IBattler
    {
        public CharacterParams Params { get; }

        public string Name => Params.Name;
        public int Health => Params.Health;
        public int Damage => Params.Damage;


        public void TakeDmg(int dmg);
    }
}
