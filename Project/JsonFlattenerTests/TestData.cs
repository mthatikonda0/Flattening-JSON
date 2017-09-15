using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject;

namespace JsonFlattenerTests
{
    // Used as a repository for testing data
    public static class TestData
    {
        // Test input data given in object form
        public static JsonMapper Input1 = new JsonMapper
        {
            id = 1,
            name = "Mounish",
            groups = new List<Group>
            {
                new Group {
                    id = 10,
                    name = "country",
                    subgroups = new List<Group>
                    {
                        new Group
                        {
                            id = 11,
                            name = "state"

                        },
                        new Group
                        {
                            id = 12,
                            name = "providence"

                        }
                    }
                }
            }
        };

        // Expected output for the above
        public static List<Group> Output1 = new List<Group>
        {
            new Group {
                id = 10,
                name = "country",
                subgroups = new List<Group>
                {
                    new Group
                    {
                        id = 11,
                        name = "state"

                    },
                    new Group
                    {
                        id = 12,
                        name = "providence"

                    }
                }
            },
            new Group
            {
                id = 11,
                name = "state"

            },
            new Group
            {
                id = 12,
                name = "providence"
            },
        };
    }
}
