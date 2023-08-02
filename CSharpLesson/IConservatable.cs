using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public interface IConversator : IConversate
    {
        void TryToConversate(IConversatable enemy);
    }
}
