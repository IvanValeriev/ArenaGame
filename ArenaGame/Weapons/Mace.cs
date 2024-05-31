using ArenaGame.WeaponAbilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Mace : IWeapon
    {
        public string Name { get; set; }

        public double AttackDamage { get; private set; }

        public double BlockingPower { get; private set; }

        public IWeaponAbility? WeaponAbility { get; }

        public Random RNG { get; } = new Random();

        public Mace(string name)
        {
            Name = name;
            AttackDamage = 40;
            BlockingPower = 0;
            WeaponAbility = new Miss();
        }

        public bool TryAbility()
        {
            if (WeaponAbility == null) return false;

            return RNG.NextDouble() <= WeaponAbility.Chance;
        }
    }
}
