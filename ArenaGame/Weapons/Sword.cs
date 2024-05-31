using ArenaGame.WeaponAbilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Sword : IWeapon
    {
        public string Name { get; set; }

        public double AttackDamage { get; private set; }

        public double BlockingPower { get; private set; }

        public IWeaponAbility? WeaponAbility { get; }

        public Random RNG { get; }

        public Sword(string name)
        {
            Name = name;
            AttackDamage = 20;
            BlockingPower = 10;
            RNG = new Random();
        }

        public bool TryAbility()
        {
            if (WeaponAbility == null) return false;

            return RNG.NextDouble() <= WeaponAbility.Chance;
        }
    }
}
