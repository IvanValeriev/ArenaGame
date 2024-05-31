using ArenaGame.WeaponAbilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class ButcherKnife : IWeapon
    {
        public string Name { get; set; }

        public double AttackDamage { get; private set; }

        public double BlockingPower { get; private set; }

        public IWeaponAbility? WeaponAbility { get; }

        public Random RNG { get; } = new Random();

        public ButcherKnife(string name)
        {
            Name = name;
            AttackDamage = 15;
            BlockingPower = 0.2;
            WeaponAbility = new IgnoreDefense();
        }

        public bool TryAbility()
        {
            if (WeaponAbility == null) return false;

            return RNG.NextDouble() <= WeaponAbility.Chance;
        }
    }
}
