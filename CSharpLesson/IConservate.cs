using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public interface IConversatable : IConversate
    {
        bool IsConversatable { get; }
        void Conversating(IConversate enemy);
    }
}
