using StreamParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamParser.Services
{
    public class ScoreService : IScoreService
    {
        private IGroup _group;
        private IResult<int> result = null;

        public ScoreService() { }

        public void setGroup(IGroup group)
        {
            this._group = group;
        }

        private void Score()
        {
            this.result = new Result();
            Dictionary<int, int> dict = this._group.getGroupPair();
            if (dict == null)
            {
                this.result.Score = -1;
                return;
            }
            foreach (var pair in dict)
            {
                this.result.Score += pair.Key * pair.Value;
            }
        }

        public IResult<int> getResult() { if (result == null) this.Score(); return this.result; }

    }


    public interface IScoreService
    {
        void setGroup(IGroup group);
        IResult<int> getResult();
        
    }


}
