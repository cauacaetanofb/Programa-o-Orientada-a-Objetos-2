using System.Drawing;

namespace SimplePongGame
{
    public class CPU : Paddle
    {
        public CPU(int x, int y, Difficulty difficulty)
        {
            Position = new Point(x, y);

            // Define a velocidade com base na dificuldade
            if (difficulty == Difficulty.EASY) speed = 3;
            if (difficulty == Difficulty.MEDIUM) speed = 6;
            if (difficulty == Difficulty.HARD) speed = 9;
        }

        public void UpdatePosition(Point ballPosition)
        {
            if (ballPosition.Y > Position.Y)
            {
                Position = new Point(Position.X, Position.Y + speed);
            }
            if (ballPosition.Y < Position.Y)
            {
                Position = new Point(Position.X, Position.Y - speed);
            }
        }
    }
}