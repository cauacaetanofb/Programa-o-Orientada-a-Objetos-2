using System.Drawing;
using System.Windows.Forms;

namespace SimplePongGame
{
    public partial class Form1 : Form
    {
        private Game game;
        private bool isUpPressed, isDownPressed;
        private bool isWPressed, isSPressed;

        public Form1(GameMode mode, Difficulty difficulty = Difficulty.EASY)
        {
            InitializeComponent();
            game = new Game(mode, difficulty);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                isUpPressed = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                isDownPressed = true;
            }
            if (e.KeyCode == Keys.W)
            {
                isWPressed = true;
            }
            if (e.KeyCode == Keys.S)
            {
                isSPressed = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                isUpPressed = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                isDownPressed = false;
            }
            if (e.KeyCode == Keys.W)
            {
                isWPressed = false;
            }
            if (e.KeyCode == Keys.S)
            {
                isSPressed = false;
            }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            // O Form1 agora envia o estado das teclas de ambos os jogadores
            game.UpdatePlayer(isUpPressed, isDownPressed, isWPressed, isSPressed);

            game.Update();

            player.Location = new Point(player.Location.X, game.GetPlayer1Position().Y);
            cpu.Location = new Point(cpu.Location.X, game.GetPlayer2Position().Y);
            ball.Location = game.GetBallPosition();

            playerScore.Text = game.GetPlayer1Score().ToString();
            cpuLabel.Text = game.GetPlayer2Score().ToString();

            if (game.IsGameOver())
            {
                gameTimer.Stop();
                string winner = game.GetWinner();
                MessageBox.Show(winner + " venceu o jogo!");
            }
        }
    }
}