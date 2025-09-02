using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePongGame
{
    public class MenuForm : Form
    {
        private Button btnSinglePlayer;
        private Button btnMultiplayer;
        private Label lblDifficulty;
        private ComboBox cmbDifficulty;
        private Label lblTitle;

        public MenuForm()
        {
            this.Text = "Menu Principal";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Título
            lblTitle = new Label();
            lblTitle.Text = "Jogo de Pong";
            lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTitle.Size = new Size(300, 40);
            lblTitle.Location = new Point(50, 20);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Botão 1 Jogador
            btnSinglePlayer = new Button();
            btnSinglePlayer.Text = "1 Jogador";
            btnSinglePlayer.Size = new Size(150, 40);
            btnSinglePlayer.Location = new Point(115, 80);
            btnSinglePlayer.Click += new EventHandler(btnSinglePlayer_Click);

            // Botão 2 Jogadores
            btnMultiplayer = new Button();
            btnMultiplayer.Text = "2 Jogadores";
            btnMultiplayer.Size = new Size(150, 40);
            btnMultiplayer.Location = new Point(115, 130);
            btnMultiplayer.Click += new EventHandler(btnMultiplayer_Click);

            // Rótulo de Dificuldade
            lblDifficulty = new Label();
            lblDifficulty.Text = "Dificuldade:";
            lblDifficulty.Size = new Size(100, 20);
            lblDifficulty.Location = new Point(50, 190);

            // ComboBox de Dificuldade
            cmbDifficulty = new ComboBox();
            cmbDifficulty.Items.Add("Fácil");
            cmbDifficulty.Items.Add("Médio");
            cmbDifficulty.Items.Add("Difícil");
            cmbDifficulty.SelectedIndex = 0;
            cmbDifficulty.Size = new Size(150, 20);
            cmbDifficulty.Location = new Point(150, 190);

            // Adiciona todos os componentes ao formulário
            this.Controls.Add(lblTitle);
            this.Controls.Add(btnSinglePlayer);
            this.Controls.Add(btnMultiplayer);
            this.Controls.Add(lblDifficulty);
            this.Controls.Add(cmbDifficulty);
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            Difficulty selectedDifficulty = (Difficulty)cmbDifficulty.SelectedIndex;

            Form1 gameForm = new Form1(GameMode.SINGLE_PLAYER, selectedDifficulty);
            gameForm.Show();
            this.Hide();
        }

        private void btnMultiplayer_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1(GameMode.MULTI_PLAYER, Difficulty.EASY);
            gameForm.Show();
            this.Hide();
        }
    }
}