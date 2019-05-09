using StreamParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamParser.Services
{
    public class StreamPosService : IStreamPos<IInput<string>>
    {
        private string _input=null;
        private int _index=0;

        public StreamPosService() { }

        public void SetInput(IInput<string> input)
        {
            this._input = input._input;
        }
        public void SetIndex(int index)
        {
            this._index = index;
            if (_index < 0)
                _index = 0;
            if (_index >= _input.Length)
                _index = _input.Length;
        }
        public void SetAll(IInput<string> input, int index)
        {
            this.SetInput(input);
            this.SetIndex(index);
        }
        public bool MoveRight()
        {
            ++_index;
            return CanContinue;

        }
        public bool CanContinue => _index < _input.Length ? true : false;
        public bool EndOfStream => !CanContinue;
        public char? Current => CanContinue ? _input[_index] : (char?)null;
    }
}
