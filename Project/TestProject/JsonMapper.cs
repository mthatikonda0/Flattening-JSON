using System.Collections.Generic;

namespace TestProject
{
    public class JsonMapper
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Group> groups { get; set; }
    }

    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Group> subgroups { get; set; }
         

        //  for testing purpose

        public Group()
        {
            subgroups = new List<Group>();
        }
        

        public bool RecursivelyEquals(Group anotherGroup)
        {
            if (this.id != anotherGroup.id)
                return false;

            if (this.name != anotherGroup.name)
                return false;

            if (this.subgroups.Count != anotherGroup.subgroups.Count)
                return false;

            // Need to make sure each of our subgroups also matches the other
            // group's subgroups
            for (int i = 0; i < this.subgroups.Count; i++)
            {
                var mySubgroup = this.subgroups[i];
                var theirSubgroup = anotherGroup.subgroups[i];

                if (!mySubgroup.RecursivelyEquals(theirSubgroup))
                    return false;
            }

            // At this point, all checks have passed. We are equal!
            return true;
        }
    }
}