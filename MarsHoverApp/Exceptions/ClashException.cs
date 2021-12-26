using System.Runtime.Serialization;

namespace MarsHoverApp
{
    [Serializable]
    public class ClashException : Exception
    {
        public ClashException()
        {
        }
        public ClashException(string? message) : base(message)
        {
        }

        public ClashException(int hoverToClash, int hoverThatClashed) 
            : base($"A clash with hover {hoverToClash} has happened when moving Hover {hoverThatClashed}.")
        {

        }
    }
}