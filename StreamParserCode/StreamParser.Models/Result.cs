using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamParser.Models
{
    public class Result: IResult<int>
    {
        public int Score { get; set; }
        public Result() { this.Score = 0; }
    }

    public interface IResult<T>
    {
        T Score { get; set; }
    }
}
