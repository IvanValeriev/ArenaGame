using ArenaGame.WeaponAbilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class GameEngine
    {
        public class NotificationArgs
        {
            public Hero Attacker { get; set; }
            public Hero Defender { get; set; }
            public double Attack { get; set; }
            public double Damage { get; set; }
            public string AttackPrefix { get; set; }
        }

        public delegate void GameNotifications(NotificationArgs args);

        private Random random = new Random();
        public Hero HeroA { get; set; }
        public Hero HeroB { get; set; }
        public Hero Winner { get; set; }
        public GameNotifications? NotificationsCallBack { get; set; }

        public void Fight()
        {
            Hero attacker;
            Hero defender;

            double probability = random.NextDouble();
            if (probability < 0.5)
            {
                attacker = HeroA;
                defender = HeroB;
            } else
            {
                attacker = HeroB;
                defender = HeroA;
            }

            while (attacker.IsAlive)
            {
                double attackDamage = attacker.Attack();
                string attackPrefix = "";
                IWeapon attackerWeapon = attacker.Weapon;

                bool abilityTriggered = attackerWeapon.WeaponAbility != null && attackerWeapon.TryAbility();

                if (abilityTriggered)
                {
                    attackPrefix = attackerWeapon.WeaponAbility.Prefix;
                    attackDamage = attackerWeapon.WeaponAbility.Enhance(attackDamage);
                }

                double realDamage = defender.Defend(attackDamage);

                if (abilityTriggered && attacker.Weapon.WeaponAbility is IgnoreDefense)
                {
                    realDamage = attackDamage;
                }

                if (NotificationsCallBack != null)
                {
                    NotificationsCallBack(new NotificationArgs()
                    {
                        Attacker = attacker,
                        Defender = defender,
                        Attack = attackDamage,
                        Damage = realDamage,
                        AttackPrefix = attackPrefix
                    }); 
                }

                Hero tempHero = attacker;
                attacker = defender;
                defender = tempHero;
            }

            Winner = defender;
        }
    }
}
