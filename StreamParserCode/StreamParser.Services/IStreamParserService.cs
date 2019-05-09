using StreamParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamParser.Services
{
    public interface IStreamParserService<T1,T2>
    {
        void setInput(T1 content);

        IGroup Parse();

        bool isGarbage(T2 c);

        bool isGroup(T2 c);

        bool isIgnore(T2 c);
    }
}
