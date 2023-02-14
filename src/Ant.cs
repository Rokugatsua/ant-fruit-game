using Vector;

public class Ant{
    public Vector2 position;
    string _antName;

    public Ant(float x, float y, string name) {
        position = new Vector2(x, y);
        _antName = name;

    }
}