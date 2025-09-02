namespace SimplePongGame
{
    public class Score
    {
        public int Player1Points { get; private set; }
        public int Player2Points { get; private set; }

        public void IncrementPlayer1()
        {
            Player1Points++;
        }

        public void IncrementPlayer2()
        {
            Player2Points++;
        }
    }
}