using ArenaGame.WeaponAbilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Hammer : IWeapon
    {
        public string Name { get; set; }

        public double AttackDamage { get; private set; }

        public double BlockingPower { get; private set; }

        public IWeaponAbility? WeaponAbility { get; }

        public Random RNG { get; } = new Random();

        public Hammer(string name)
        {
            Name = name;
            AttackDamage = 13;
            BlockingPower = 4;
            WeaponAbility = new DoubleDamage();
        }

        public bool TryAbility()
        {
            if (WeaponAbility == null) return false;

            return RNG.NextDouble() <= WeaponAbility.Chance;
        }
    }
}
