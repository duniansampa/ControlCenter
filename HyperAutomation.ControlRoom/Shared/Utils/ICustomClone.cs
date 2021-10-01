using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Shared.Utils
{
    public interface ICustomClone<T>
    {
        T CreateShallowCopy();
    }
}
