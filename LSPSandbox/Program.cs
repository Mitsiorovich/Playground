namespace LSPExample
{
    public abstract class Shape()
    {
        public abstract int GetArea();
    }

    public class Rectangle: Shape
    {
        public  int Width { get; set; }
        public  int Height { get; set; }

        public override int GetArea() => Width * Height;
    }

    public class Square : Shape
    {
        public int SideWidth { get; set; }
        public override int GetArea() => SideWidth * SideWidth;
    }
}
