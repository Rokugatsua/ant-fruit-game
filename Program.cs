using Vector;
using World;
class Program
{
    static void Main(string[] args)
    {

        Board board = new Board(7, 7);
        Move worldMove = new Move(board);

        Vector2 antPosition = worldMove.GetRandomPosition();
        Vector2 fruitPosition = worldMove.GetRandomPosition();
        Ant keyleAnt = new Ant(antPosition.x, antPosition.y, "keyle");
        Fruit fruit = new Fruit(fruitPosition.x, fruitPosition.y);

        int bomsInBoard = (int)(board.GetSize().x * board.GetSize().y) / (int)(board.GetSize().x / 2);
        Bom[] boms = new Bom[bomsInBoard] ;


        // iterate boms
        for (var i=0; i < bomsInBoard; i++) {
            Vector2 bomPosition = Vector2.Zero;
            bool isGetRandom = true;
            while(isGetRandom) {

                // to get different position per object
                bomPosition = worldMove.GetRandomPosition();
                if (bomPosition != keyleAnt.position && bomPosition != fruit.position) {
                    isGetRandom = false;
                    foreach(Bom localBom in boms) {
                        if (localBom == null) {
                            continue;
                        }
                        if (bomPosition == localBom.position) {
                            isGetRandom = true;
                        }
                    }
                }
            }
            Bom bom = new Bom(bomPosition.x, bomPosition.y);
            boms[i] = bom;
        }


        
        int stepMove = (int)(board.GetSize().x + board.GetSize().y);

        Console.WriteLine("move only accepted: left, right, up, down");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("x : player");
        Console.WriteLine("o : fruit");
        Console.WriteLine("0 : Bom");
        Console.WriteLine("-----------------------------------------");
        
        // First board 
        PrintToConsole(board, boms, keyleAnt.position, fruit.position, stepMove);

        for (var i = 0; i < stepMove; i++)
        {
            // Get input by player
            var move = Console.ReadLine();

            // Move
            if (move == "left")
            {
                Move.MoveTo(ref keyleAnt.position, Vector2.Left);
            }
            else if (move == "right")
            {
                Move.MoveTo(ref keyleAnt.position, Vector2.Right);
            }
            else if (move == "up")
            {
                Move.MoveTo(ref keyleAnt.position, Vector2.Up);
            }
            else if (move == "down")
            {
                Move.MoveTo(ref keyleAnt.position, Vector2.Down);
            }
            else
            {
                Console.WriteLine(move + " not right input move.");
            }


            // Print the board
            PrintToConsole(board, boms, keyleAnt.position, fruit.position, (stepMove - (i + 1)));


            // checking if player position on Goal or hit bom
            if (keyleAnt.position  == fruitPosition){
                Console.WriteLine("YOU WIN");
                return;
            } else {
                foreach (Bom pBom in boms) {
                    if (keyleAnt.position == pBom.position) {
                        Console.WriteLine("YOU LOSE");
                        return;
                    }
                }
            }
        }

        // player runout movement
        Console.WriteLine("YOU LOSE");
    }

    static void PrintToConsole(Board board,Bom[] boms, Vector2 antPosition, Vector2 fruitPosition, int stillMove){
        Console.WriteLine("-----------------");
        Console.WriteLine("move still : " + (stillMove));
        Console.WriteLine("-----------------");
        board.Show(antPosition, fruitPosition, boms);
        Console.WriteLine("-----------------");
    }
}