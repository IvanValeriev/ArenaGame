using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Berserker : Hero
    {
        public Berserker(string name, double armor, double strenght, IWeapon weapon) :
            base(name, armor, strenght, weapon)
        { }

        public override double Attack()
        {
            double damage = base.Attack();

            if (random.NextDouble() < 0.03)
            {
                damage *= 3;
            }

            return damage;
        }
    }
}
