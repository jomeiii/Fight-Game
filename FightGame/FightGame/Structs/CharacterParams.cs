namespace FightGame.Structs
{
    public struct CharacterParams
    {
        public string Name;
        public int Health;
        public int Damage;
        public int MissChance; 
        

        public CharacterParams(string name, int health, int damage, int missChance)
        {
            Name = name;
            Health = health;
            Damage = damage;
            MissChance = missChance;
        }
    }
}