using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class JsonFlattener
    {
        public static List<Group> Flatten(JsonMapper userInformation)
        {
            var userGroups = new List<Group>();
            if (userInformation.groups.Count > 0)
            {
                //Loop through all groups
                foreach (var userGroup in userInformation.groups)
                {
                    userGroups.Add(userGroup);
                    if (userGroup.subgroups.Count > 0)
                    {
                        //Loop thorough all first layer subgroups
                        foreach (var subgroup in userGroup.subgroups)
                        {
                            //get nested groups by calling all subgroups until the count is 0
                            var nestedGroups = GetIndividualSubGroupsForUser(subgroup);
                            userGroups.AddRange(nestedGroups);

                        }
                    }

                }
            }
            return userGroups;

        }

        public static List<Group> GetIndividualSubGroupsForUser(Group subGroup)
        {
            Func<Group, List<Group>> nestedSubGroups = null;

            nestedSubGroups = (nestedSubGroup) =>
            {
                var myNestedSubGroups = new List<Group>();
                // Add ourself to the list
                myNestedSubGroups.Add(nestedSubGroup);

                // Do we have any children?
                // If so, we need to add them too..
                foreach (var grp in nestedSubGroup.subgroups)
                {
                    myNestedSubGroups.AddRange(nestedSubGroups(grp));
                }
                return myNestedSubGroups;
            };
            var result = nestedSubGroups(subGroup);

            return result;
        }

        public static JsonMapper LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                //Deserialize json object and map it to JsonMapper
                var MemberDetails = JsonConvert.DeserializeObject<JsonMapper>(json);
                return MemberDetails;
            }
        }

        public static void WriteJson(string path, List<Group> groups)
        {
            using (StreamWriter r = new StreamWriter(path, false))
            {
                // Serialize completed object to a json string
                string json = JsonConvert.SerializeObject(groups, Formatting.Indented);
                // Write it to the result file
                r.Write(json);
            }
        }
    }
}
