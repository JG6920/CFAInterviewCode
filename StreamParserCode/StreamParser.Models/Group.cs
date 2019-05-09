using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamParser.Models
{
    public class Group : IGroup
    {
        public Dictionary<int, int> dictGroup { get; }

        public Group() { dictGroup = new Dictionary<int, int>(); }

        public void AddNewLevel(int level) { this.dictGroup.Add(level, 1); }

        public void AddGroup(int level)
        {
            if (this.dictGroup.ContainsKey(level)) { ++this.dictGroup[level]; }
            else { this.AddNewLevel(level); }

        }

        public Dictionary<int, int> getGroupPair() { if (dictGroup.Count == 0) return null; return this.dictGroup; }


    }

    public interface IGroup
    {
        void AddNewLevel(int level);
        void AddGroup(int level);
        Dictionary<int, int> getGroupPair();
    }

}
