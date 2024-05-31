using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public interface IWeaponAbility
    {
        double Chance { get; protected set; }
        double Enhance(double attackDamage);
        public string Prefix { get; }
    }
}
