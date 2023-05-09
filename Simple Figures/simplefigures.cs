using System;
using System.Collections.Generic;

namespace Simple_Figures
{
    internal class simplefigures
    {
        static void Main(string[] args)
        {
            // create some points
            Point p1 = new Point(0, 0);
            Point p2 = new Point(3, 4);
            Point p3 = new Point(-2, 1);

            // create some lines
            Line line1 = new Line(p1, p2);
            Line line2 = new Line(p2, p3);

            // create a circle
            Circle circle = new Circle(p2, 2);

            // create an aggregation of figures
            List<object> figures = new List<object>();
            figures.Add(p1);
            figures.Add(line1);
            figures.Add(line2);
            figures.Add(circle);
            Aggregation aggregation = new Aggregation(figures);

            // move and rotate the figures
            p1.Move(1, 1);
            line1.Rotate(45);
            circle.Move(-2, 3);
            aggregation.Move(2, 2);
            aggregation.Rotate(30);

            // print the current positions of the figures
            Console.WriteLine($"p1: ({p1.X}, {p1.Y})");
            Console.WriteLine($"p2: ({p2.X}, {p2.Y})");
            Console.WriteLine($"p3: ({p3.X}, {p3.Y})");
            Console.WriteLine($"line1 start: ({line1.Start.X}, {line1.Start.Y})");
            Console.WriteLine($"line1 end: ({line1.End.X}, {line1.End.Y})");
            Console.WriteLine($"line2 start: ({line2.Start.X}, {line2.Start.Y})");
            Console.WriteLine($"line2 end: ({line2.End.X}, {line2.End.Y})");
            Console.WriteLine($"circle center: ({circle.Center.X}, {circle.Center.Y}), radius: {circle.Radius}");
            Console.WriteLine("Aggregation:");
            foreach (object figure in aggregation.Figures)
            {
                if (figure is Point)
                {
                    Point point = (Point)figure;
                    Console.WriteLine($"  point: ({point.X}, {point.Y})");
                }
                else if (figure is Line)
                {
                    Line line = (Line)figure;
                    Console.WriteLine($"  line start: ({line.Start.X}, {line.Start.Y}), end: ({line.End.X}, {line.End.Y})");
                }
                else if (figure is Circle)
                {
                    Circle circle2 = (Circle)figure;
                    Console.WriteLine($"  circle center: ({circle2.Center.X}, {circle2.Center.Y}), radius: {circle2.Radius}");
                }
            }
        }
    }

    // Point class
    public class Point
    {
        //get and set are used to encapsulate the implementation
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            //set the value of X and Y coordinate
            X = x;
            Y = y;
        }

        public void Move(double dx, double dy)
        {
            //dx = the amount this point should moved in x direction
            //dy = the amount this point should moved in y direction

            X += dx;
            Y += dy;
        }

        public void Rotate(double angle)
        {
            //Convert from degree to radian
            double rad = angle * Math.PI / 180.0;
            //X and Y = origin coordinates
            //x and y = coordinates after the point was rotated
            double x = X * Math.Cos(rad) - Y * Math.Sin(rad);
            double y = X * Math.Sin(rad) + Y * Math.Cos(rad);
            //Store new coordinates to X and Y
            X = x;
            Y = y;
        }
    }

    // Line class
    public class Line
    {
        //Define start and end coordinate by using point from previous class
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(Point start, Point end)
        {
            //Set the start and end point of a line
            Start = start;
            End = end;
        }

        public void Move(double dx, double dy)
        {
            //Move the line
            Start.Move(dx, dy);
            End.Move(dx, dy);
        }

        public void Rotate(double angle)
        {
            //Rotate the line
            Start.Rotate(angle);
            End.Rotate(angle);
        }
    }

    // Circle class
    public class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public Circle(Point center, double radius)
        {
            //Set the center and radius of the circle
            Center = center;
            Radius = radius;
        }

        public void Move(double dx, double dy)
        {
            //Move the circle by moving the center point of the circle
            Center.Move(dx, dy);
        }
        
        public void Rotate(double angle)
        {
            //Rotate the circle by rotating the center point of the circle
            Center.Rotate(angle);
        }
    }

    // Aggregation class
    public class Aggregation
    {
        //Define Figures that will consist of a list of objects
        public List<object> Figures { get; set; }

        //Initialize the Figures
        public Aggregation(List<object> figures)
        {
            Figures = figures;
        }

        public void Move(double dx, double dy)
        {
            foreach (object figure in Figures)
            {
                if (figure is Point)
                {
                    //Convert the object type of figure to Point and move it
                    ((Point)figure).Move(dx, dy);
                }
                else if (figure is Line)
                {
                    //Convert the object type of figure to Line and move it
                    ((Line)figure).Move(dx, dy);
                }
                else if (figure is Circle)
                {
                    //Convert the object type of figure to Circle and move it
                    ((Circle)figure).Move(dx, dy);
                }
                else if (figure is Aggregation)
                {
                    //Convert the object type of figure to Aggregation and move it
                    ((Aggregation)figure).Move(dx, dy);
                }
            }
        }

        public void Rotate(double angle)
        {
            foreach (object figure in Figures)
            {
                if (figure is Point)
                {
                    //Convert the object type of figure to Point and rotate it
                    ((Point)figure).Rotate(angle);
                }
                else if (figure is Line)
                {
                    //Convert the object type of figure to Line and rotate it
                    ((Line)figure).Rotate(angle);
                }
                else if (figure is Circle)
                {
                    //Convert the object type of figure to Circle and rotate it
                    ((Circle)figure).Rotate(angle);
                }
                else if (figure is Aggregation)
                {
                    //Convert the object type of figure to Aggregation and rotate it
                    ((Aggregation)figure).Rotate(angle);
                }
            }
        }
    }
}
