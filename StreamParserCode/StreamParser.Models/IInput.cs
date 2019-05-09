using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamParser.Models
{
    public interface IInput<T>
    {
        T _input { get; set; }
    }
}
