using FightGame.Interfaces;
using FightGame.Structs;

namespace FightGame.Scripts.NPCs
{
    public abstract class NPC : IBattler
    {
        protected CharacterParams _params;
        protected Inventory _inventory;
        protected string _name;

        public CharacterParams Params => _params;
        public Inventory inventory => _inventory;
        public string Name => _name;
        public int Protection => _inventory.TotalProtection;
        public int ProtectionQuality => _inventory.TotalProtectionQuality;

        public NPC(string name, int health, int damage, int missChance, Inventory inventory)
        {
            _name = name;
            _params = new CharacterParams(health, damage, missChance);
            _inventory = inventory;
        }

        public virtual void Speak()
        {
            Console.WriteLine("Я NPC");
        }

        public void TakeDmg(int damage)
        {
            if (_inventory.TotalProtection > 0)
            {
                _inventory.TotalProtection -= damage * _inventory.TotalProtectionQuality / 100;
                damage -= damage * _inventory.TotalProtectionQuality / 100;
                if (_inventory.TotalProtectionQuality < 0)
                    damage += _inventory.TotalProtectionQuality * -1;
            }

            _params.Health -= damage;
        }

        public void PrintStats()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\nХарактеристики протикника");
            Console.WriteLine($"Имя: {Name}, Здоровье: {_params.Health}, Урон: {_params.Damage}, " +
                $"Защита {_inventory.TotalProtection}, Качество защиты {_inventory.TotalProtectionQuality}, " +
                $"Шанс промаха: {_params.MissChance}%\n");

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}