// See https://aka.ms/new-console-template for more information
using System.Runtime.Serialization;
namespace MarsHoverApp
{
    [Serializable]
    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException() : base("Input was invalid. Please enter a valid input.")
        {
        }

    }
}