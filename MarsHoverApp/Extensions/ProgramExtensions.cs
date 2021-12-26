using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsHoverApp.Extensions
{
    public static class ProgramExtensions
    {
        public static Field CheckAndCreateField(string[]? inputs)
        {
            //Expected format; X length, Y length
            if (inputs?.Length != 2)
            {
                throw new InvalidArgumentException();
            }

            if (!int.TryParse(inputs[0], out int vertical) || !int.TryParse(inputs[1], out int horizontal))
            {
                throw new InvalidArgumentException();
            }

            var field = new Field(vertical, horizontal);
            Console.WriteLine($"Mars field with size [{vertical},{horizontal}] has been created.");
            return field;
        }
        public static Hover CheckAndCreateHover(string[]? inputs, Field field)
        {
            //Expected format; XAxis, YAxis, Alignment
            if (inputs?.Length != 3)
            {
                throw new InvalidArgumentException();
            }

            if (!int.TryParse(inputs[0], out int hoverX) || !int.TryParse(inputs[1], out int hoverY) || !char.TryParse(inputs[2], out char facing))
            {
                throw new InvalidArgumentException();
            }
            
            if(hoverX > field.HorizontalSize || hoverY > field.VerticalSize)
            {
                throw new InvalidArgumentException();
            }
            //Check if there are any existing hovers in the given spot already.
            foreach (Hover hover in field.Hovers)
            {
                if (hover.XAxisPosition == hoverX && hover.YAxisPosition == hoverY)
                {
                    throw new ClashException($"In coordinates[{hoverX},{hoverY}], there is already an existing hover.");
                }
            }
            var align = HoverExtensions.GetAlignmentToEnum(facing);
            var hoverToDeploy = new Hover(hoverX, hoverY, align);

            return hoverToDeploy;
        }
        public static void CheckMovementInput(string? inputMovement)
        {
            //Expected format; a string with only M, L or R
            if (inputMovement?.Length < 1)
            {
                throw new InvalidArgumentException();
            }

            if (inputMovement.ToList().SkipWhile(x => x == (char)Movement.Move || x == (char)Movement.Left || x == (char)Movement.Right).ToList().Count() > 0)
            {
                throw new InvalidArgumentException();
            }
        }
    }
}
