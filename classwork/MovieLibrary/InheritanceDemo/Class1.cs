using System;

namespace InheritanceDemo
{
    public abstract class Shape
    {
        public Point Origin { get; set; }

        public abstract void Draw ();

        public virtual void DisplayText ()
        {
            Console.WriteLine("Shape");
        }
    }

    public class DrawingList
    {
        public void Sample ()
        {
            var list = new DrawingList();

            var circle = new Circle();
            circle.Radius = 10;

            list.Shape1 = circle;

            var rect = new Rectangle();
            rect.TopLeft = new Point(10, 10);
            rect.BottomRight = new Point(100, 100);

            list.Shape2 = rect;
        }

        public Shape Shape1 { get; set; }
        public Shape Shape2 { get; set; }
        public Shape Shape3 { get; set; }
        public Shape Shape4 { get; set; }
        public Shape Shape5 { get; set; }

        public void Draw ()
        {
            Shape1?.Draw();
            Shape2?.Draw();
            Shape3?.Draw();
            Shape4?.Draw();
            Shape5?.Draw();
        }
    }

    public class Circle : Shape
    {
        public int Radius { get; set; }

        public override void Draw ()
        { 
            //Draw a circle
        }

        public override void DisplayText () 
        {
            Console.WriteLine("Circle");        
        }

    }

    public class Rectangle : Shape
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public override void Draw ()
        {
            //Draw rectangle
        }
    }
}
