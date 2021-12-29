using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsHoverApp.Extensions
{
    public static class HoverExtensions
    {
        public static int CheckClashToOtherHoverIn(this Hover hover, Field field)
        {
            foreach(Hover h in field.Hovers)
            {
                if(h.HoverId != hover.HoverId &&(h.XAxisPosition == hover.XAxisPosition && h.YAxisPosition == hover.YAxisPosition))
                {
                    return h.HoverId;
                }
            }
            return -1;
        }
        public static char GetAlignmentFromEnum(this Alignment align)
        {
            switch (align)
            {
                case (Alignment.N):
                    return 'N';
                case (Alignment.E):
                    return 'E';
                case(Alignment.S):
                    return 'S';
                case (Alignment.W):
                    return 'W';
                default:
                    return ' ';
            }
        }
        public static Alignment ToEnum(this char align)
        {
            switch (align)
            {
                case ('N'):
                    return Alignment.N;
                case ('E'):
                    return Alignment.E;
                case ('S'):
                    return Alignment.S;
                case ('W'):
                    return Alignment.W;
                default:
                    return Alignment.N;
            }
        }
    }
}
