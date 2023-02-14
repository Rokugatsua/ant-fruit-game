using Vector;

public class Board
{
    private Vector2 _size;

    public Board(int width, int height) {
        _size = new Vector2(width, height);
    }
    
    public void Show(Vector2 antPosition, Vector2 fruitPosition, Bom[] boms){
        for (var i=0; i < _size.y ; i++) {
            for (var j=0; j < _size.x; j++) {
                string boardTile = "[ ]";
                if (i == antPosition.y && j == antPosition.x){
                    boardTile = "[x]";
                }
                else if (i == fruitPosition.y && j == fruitPosition.x){
                    boardTile = "[o]";
                }

                foreach(Bom bom in boms) {
                    if (i == bom.position.y && j == bom.position.x ){
                        boardTile = "[0]";
                        break;
                    }
                }

                Console.Write(boardTile);
            }
            Console.Write("\n");
        }
    }
    public bool IsOutOfBoard(Vector2 position){
        if(position.x < 0 || position.x >= _size.x) {
            return true;
        } else if (position.y < 0 || position.y >= _size.y){
            return true;
        }
        return false;
    }

    public Vector2 GetSize() {
        return _size;
    }
}