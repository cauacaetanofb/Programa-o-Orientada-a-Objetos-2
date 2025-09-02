using System.Drawing;

namespace SimplePongGame
{
    public class Player : Paddle
    {
        public Player(int x, int y)
        {
            Position = new Point(x, y);
            speed = 8;
        }

        public void MoveUp()
        {
            if (Position.Y > 0)
            {
                Position = new Point(Position.X, Position.Y - speed);
            }
        }

        public void MoveDown()
        {
            if (Position.Y < 455)
            {
                Position = new Point(Position.X, Position.Y + speed);
            }
        }
    }
}