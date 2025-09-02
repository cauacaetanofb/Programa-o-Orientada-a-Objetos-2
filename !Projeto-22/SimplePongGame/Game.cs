using System.Drawing;

namespace SimplePongGame
{
    public enum GameMode { SINGLE_PLAYER, MULTI_PLAYER }
    public enum Difficulty { EASY, MEDIUM, HARD }

    public class Game
    {
        private const int MAX_SCORE = 10;
        private Ball ball;
        private Player player1;
        private Paddle player2;
        private Score score;
        private GameMode mode;

        public Game(GameMode mode, Difficulty difficulty = Difficulty.EASY)
        {
            this.mode = mode;

            ball = new Ball(new Point(434, 239), new Point(5, 5));
            player1 = new Player(12, 186);
            score = new Score();

            if (mode == GameMode.SINGLE_PLAYER)
            {
                player2 = new CPU(897, 230, difficulty);
            }
            else // Modo MULTI_PLAYER
            {
                player2 = new Player(897, 230);
            }
        }

        public void Update()
        {
            ball.Move();

            if (mode == GameMode.SINGLE_PLAYER && player2 is CPU cpu)
            {
                cpu.UpdatePosition(ball.Position);
            }

            if (ball.Position.Y < 0 || ball.Position.Y > 574 - 26)
            {
                ball.InvertVelocityY();
            }

            if (ball.CheckCollision(player1) || ball.CheckCollision(player2))
            {
                ball.InvertVelocityX();
            }

            if (ball.Position.X < 0)
            {
                score.IncrementPlayer2();
                ball.ResetPosition();
            }
            if (ball.Position.X > 928)
            {
                score.IncrementPlayer1();
                ball.ResetPosition();
            }
        }

        // Novo método para atualizar ambos os jogadores
        public void UpdatePlayer(bool p1_up, bool p1_down, bool p2_up, bool p2_down)
        {
            // Lógica para mover o jogador 1
            if (p1_up) player1.MoveUp();
            if (p1_down) player1.MoveDown();

            // Lógica para mover o jogador 2
            if (mode == GameMode.MULTI_PLAYER)
            {
                // A raquete do Jogador 2 só se move se o modo for multiplayer
                if (p2_up) ((Player)player2).MoveUp();
                if (p2_down) ((Player)player2).MoveDown();
            }
        }

        public Point GetBallPosition() { return ball.Position; }
        public Point GetPlayer1Position() { return player1.Position; }
        public Point GetPlayer2Position() { return player2.Position; }
        public int GetPlayer1Score() { return score.Player1Points; }
        public int GetPlayer2Score() { return score.Player2Points; }

        public bool IsGameOver()
        {
            return score.Player1Points >= MAX_SCORE || score.Player2Points >= MAX_SCORE;
        }

        public string GetWinner()
        {
            if (score.Player1Points >= MAX_SCORE) return "Você";
            if (score.Player2Points >= MAX_SCORE) return "A máquina";
            return "Ninguém";
        }
    }
}