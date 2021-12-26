using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsHoverApp
{
    public interface IHover
    {
        void Move(string movementOrder, Field field);


    }
}
