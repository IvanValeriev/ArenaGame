using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;

namespace WinFormArenaGame
{
    public partial class MainForm : Form
    {
        private Hero previousAttacker { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void gameNotification(GameEngine.NotificationArgs args)
        {
            TextBox tbAttacker;

            if (previousAttacker == null || previousAttacker == args.Attacker)
            {
                tbAttacker = tbLeft;
                previousAttacker = args.Attacker;
            }
            else
            {
                tbAttacker = tbRight;
                previousAttacker = args.Defender;
            }

            tbAttacker.AppendText(
                $"{args.AttackPrefix}{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.\r\n");

            DateTime dt = DateTime.Now;

            while (DateTime.Now - dt < TimeSpan.FromMilliseconds(300))
            {
                Application.DoEvents();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            lbWinner.Text = "";
            tbRight.Text = "";
            tbLeft.Text = "";
            lbWinner.Visible = false;

            GameEngine gameEngine = new GameEngine()
            {
                HeroA = new Berserker("Berserker", 10, 6, new Hammer("Mjolnir")),
                HeroB = new Tank("Tank", 10, 11, new ButcherKnife("Stacy")),
                NotificationsCallBack = gameNotification
            };

            imgFight.Enabled = true;
            gameEngine.Fight();
            imgFight.Enabled = false;

            lbWinner.Text = $"And the winner is:\n{gameEngine.Winner}";
            lbWinner.Visible = true;
        }

        private void lbWinner_Click(object sender, EventArgs e)
        {

        }
    }
}