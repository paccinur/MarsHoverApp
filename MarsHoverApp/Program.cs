// See https://aka.ms/new-console-template for more information
using MarsHoverApp.Extensions;

namespace MarsHoverApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mars Hover App.");
            Console.WriteLine("Enter the vertical and horizontal lengths of the field in that order: ");
            string area = Console.ReadLine();
            try
            {
                var inputs = area?.Split(' ');

                Field field = ProgramExtensions.CheckAndCreateField(inputs);

                while (true)
                {
                    Console.WriteLine("Enter the initial coordinates (X, Y) and facing direction(N, S, W, E) for the hover: ");
                    var hoverVars = Console.ReadLine();
                    inputs = hoverVars?.Split(' ');

                    Hover hoverToDeploy = ProgramExtensions.CheckAndCreateHover(inputs, field);

                    field.AddHover(hoverToDeploy);

                    Console.WriteLine("_______________________o[]o ==> _-^-____________________________________________");
                    Console.WriteLine($"Hover with ID {hoverToDeploy.HoverId} has been created and successfully deployed.");

                    Console.WriteLine("Enter movement directions for the hover (L for turning left, R for turning right, M to move) :");

                    var inputMovement = Console.ReadLine();

                    ProgramExtensions.CheckMovementInput(inputMovement);

                    hoverToDeploy.Move(inputMovement, field);

                    Console.WriteLine($"Hover {hoverToDeploy.HoverId} successfully moved.");
                    Console.WriteLine($"Final position: {hoverToDeploy.XAxisPosition}, {hoverToDeploy.YAxisPosition}, {hoverToDeploy.Align.GetAlignmentFromEnum()}.");
                    Console.WriteLine("Write exit to stop, enter to continue adding hovers.");

                    var exit = Console.ReadLine();
                    if (exit == "exit")
                    {
                        break;
                    }
                }
            }
            catch (InvalidArgumentException iae)
            {
                Console.WriteLine(iae.Message);
            }
            catch (ClashException ce)
            {
                Console.WriteLine(ce.Message);
            }
            finally
            {
                Console.WriteLine("Game over.");
            }
        }
        
    }
}