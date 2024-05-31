using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Assassin : Hero
    {
        public Assassin(string name, double armor, double strenght, IWeapon weapon) : 
            base(name, armor, strenght, weapon) { } 

        public override double Attack()
        {
            double damage = base.Attack();

            if (random.NextDouble() < 0.10)
            {
                damage *= 4.3;
            }

            return damage;
        }
    }
}
