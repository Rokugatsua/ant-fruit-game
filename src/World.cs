using System;
using Vector;
namespace World
{
    public class Move
    {
        public static Board board = new Board(3,3);
        
        public Move(Board board) {
            Move.board = board;
        }

        public static void MoveTo(ref Vector2 origin, Vector2 direction)
        {
            if (Move.board != null) {
                var newPosition = origin + direction;
                if (!Move.board.IsOutOfBoard(newPosition)) origin = newPosition;
            }
        }

        public Vector2 GetRandomPosition(){
            Random rand = new Random();
            int positionX = rand.Next(0, (int)Move.board.GetSize().x);
            int positionY = rand.Next(0, (int)Move.board.GetSize().y);
            return new Vector2(positionX, positionY);
        }
    }
}