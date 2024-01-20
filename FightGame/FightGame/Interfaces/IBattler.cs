using FightGame.Structs;

namespace FightGame.Interfaces
{
    public interface IBattler
    {
        public CharacterParams Params { get; }

        public string Name { get; }
        public int Health => Params.Health;
        public int Damage => Params.Damage;
        public int Protection { get; }
        public int ProtectionQuality { get; } 
        public float MissChance => Params.MissChance;

        public void TakeDmg(int dmg);
    }
}
