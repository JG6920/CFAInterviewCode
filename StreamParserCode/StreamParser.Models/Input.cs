using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamParser.Models
{
    public class Input:IInput<string>
    {
        
        public Input() { }
        public Input(string input) { this._input = input; }

        public string _input { get; set; }

    }


}
