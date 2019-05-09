using StreamParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamParser.Services
{
    public class StreamParserService :IStreamParserService<IInput<string>, char>
    {
        private int level = 0;
        private bool openGarbage = false;
        private bool shouldIgnore = false;
        private IGroup groups;
        private readonly IStreamPos<IInput<string>> _streamPos;

        public StreamParserService (IStreamPos<IInput<string>> streamPosParser)
        {
            groups = new Group();
            this._streamPos = streamPosParser;
        }

        public void setInput(IInput<string> content) { this._streamPos.SetAll(content, 0); }

        virtual public IGroup Parse()
        {
            char current;
            while (this._streamPos.CanContinue)
            {
                current = (char)this._streamPos.Current;
                if (shouldIgnore) { this.shouldIgnore = false; }
                else if (this.isIgnore(current)) { this.shouldIgnore = true; }
                else if (this.isGarbage(current)) { }
                else if (!openGarbage&&this.isGroup(current)) { }
                if (!this._streamPos.MoveRight()) break;
            }
            return groups;
        }

        virtual public bool isGarbage(char c)
        {
            if (c == '<') { if(!shouldIgnore)this.openGarbage = true; return true; }
            if (c == '>')
            {
                if (this.openGarbage)
                    this.openGarbage = false;
                return true;
            }
            return false;
        }
         
        virtual public bool isGroup(char c)
        {
            if (c == '{') { ++this.level; return true; }
            if (c == '}')
            {
                if (this.level > 0)
                {
                    this.groups.AddGroup(level);
                    --level;
                }
                else if (this.level == 0) { throw new ArgumentOutOfRangeException(); }
                return true;
            }
            return false;
        }
         
        virtual public bool isIgnore(char c)
        {
            if (c == '!') { return true; }
            return false;
        }

    }
}
