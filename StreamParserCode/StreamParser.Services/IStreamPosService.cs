using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamParser.Services
{
    public interface IStreamPos<T>
        where T:class
    {
        void SetInput(T input);
        void SetIndex(int index);
        void SetAll(T input, int index);
        bool MoveRight();

        bool CanContinue { get; }
        bool EndOfStream { get; }
        char? Current { get; }
    }
}
