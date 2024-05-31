using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.WeaponAbilities
{
    public class IgnoreDefense : IWeaponAbility
    {
        public double Chance { get; set; } = 0.20;
        public string Prefix { get; } = "[Ignoring Defense] ";

        public double Enhance(double attackDamage)
        {
            return attackDamage;
        }
    }
}