using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.WeaponAbilities
{
    internal class Miss : IWeaponAbility
    {
        public double Chance { get; set; } = 0.30;

        public string Prefix { get; } = "[Miss] ";

        public double Enhance(double attackDamage)
        {
            return 0;
        }
    }
}
