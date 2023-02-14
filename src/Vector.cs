namespace Vector
{
    public class Vector2
    {
        public float x = 0;
        public float y = 0;

        public static Vector2 Zero { get { return new Vector2(0, 0); } private set { } }
        public static Vector2 Left { get { return new Vector2(-1, 0); } private set { } }
        public static Vector2 Right { get { return new Vector2(1, 0); } private set { } }
        public static Vector2 Down { get { return new Vector2(0, 1); } private set { } }
        public static Vector2 Up { get { return new Vector2(0, -1); } private set { } }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 vectorOriginal, Vector2 vectorAdded)
            => new Vector2(vectorOriginal.x + vectorAdded.x, vectorOriginal.y + vectorAdded.y);
        public static Vector2 operator -(Vector2 vectorOriginal, Vector2 vectorAdded)
            => new Vector2(vectorOriginal.x - vectorAdded.x, vectorOriginal.y - vectorAdded.y);
        public static bool operator ==(Vector2 vectorOriginal, Vector2 vectorAdded){
            return vectorOriginal.x == vectorAdded.x && vectorOriginal.y == vectorAdded.y;
        }
        public static bool operator !=(Vector2 vectorOriginal, Vector2 vectorAdded){
            return vectorOriginal.x != vectorAdded.x && vectorOriginal.y != vectorAdded.y;
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}