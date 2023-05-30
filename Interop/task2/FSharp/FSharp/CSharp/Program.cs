using System;

namespace Program
{
    class FSharpCSharp
    {
        public static void Main()
        {
            Console.WriteLine(Program.pipe.pipe(3));
            var rectangle = Program.descrimination.Shape.NewRectangle(3, 5);
            bool isCircle = rectangle.IsCircle;
            bool isRectangle = rectangle.IsRectangle;
            Console.WriteLine(isCircle);
            Console.WriteLine(isRectangle);
            Console.WriteLine(Program.descrimination.area(rectangle));
        }
    }
}
