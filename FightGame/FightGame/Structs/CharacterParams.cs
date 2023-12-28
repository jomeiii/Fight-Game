namespace FightGame.Structs
{
    public class CharacterParams
    {
        public string Name;
        public int Health;
        public int Damage;

        public CharacterParams(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}