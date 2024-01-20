namespace FightGame.Structs
{
    public struct CharacterParams
    {
        public int Health;
        public int Damage;
        public int MissChance;

        public CharacterParams(int health, int damage, int missChance)
        {
            Health = health;
            Damage = damage;
            MissChance = missChance;
        }
    }
}