using System.Drawing;

namespace SimplePongGame
{
    public abstract class Paddle
    {
        public Point Position { get; protected set; }
        protected int speed;
    }
}