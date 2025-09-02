using System.Drawing;
using System.Windows.Forms;

namespace SimplePongGame
{
    public class Ball
    {
        public Point Position { get; private set; }
        private Point velocity;

        public Ball(Point initialPosition, Point initialVelocity)
        {
            Position = initialPosition;
            velocity = initialVelocity;
        }

        public void Move()
        {
            Position = new Point(Position.X - velocity.X, Position.Y - velocity.Y);
        }

        public bool CheckCollision(Paddle paddle)
        {
            Rectangle ballRect = new Rectangle(Position, new Size(27, 26));
            Rectangle paddleRect = new Rectangle(paddle.Position, new Size(27, 127));
            return ballRect.IntersectsWith(paddleRect);
        }

        public void InvertVelocityX()
        {
            velocity = new Point(-velocity.X, velocity.Y);
        }

        public void InvertVelocityY()
        {
            velocity = new Point(velocity.X, -velocity.Y);
        }

        public void ResetPosition()
        {
            Position = new Point(434, 239);
        }
    }
}