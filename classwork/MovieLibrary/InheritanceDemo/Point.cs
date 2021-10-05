namespace InheritanceDemo
{
    public struct Point
    {
        public Point ( int x, int y ) : this()
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }
    }
}
