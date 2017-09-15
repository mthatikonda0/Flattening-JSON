using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace JsonFlattenerTests
{
    [TestClass]
    public class TestFlatten
    {
        [TestMethod]
        public void FlattenObjectTest()
        {
            // Perform the flatten on test input 1 (this is given already in object form)
            var testResults = JsonFlattener.Flatten(TestData.Input1);
            var expectedResults = TestData.Output1;

            // Are all result groups equal to the expected groups?
            for (int i = 0; i < testResults.Count; i++)
            {
                var testResult = testResults[i];
                var expectedResult = expectedResults[i];

                Assert.IsTrue(testResult.RecursivelyEquals(expectedResult));
            }
        }

        [TestMethod]
        public void FlattenFileTest()
        {
            // Perform the flatten on test input file
            var testInput = JsonFlattener.LoadJson(".\\testdata\\input2.json");
            var testResults = JsonFlattener.Flatten(testInput);

            // Load the expected output from file
            List<Group> expectedResults = null;
            using (StreamReader r = new StreamReader(".\\testdata\\output2.json"))
            {
                expectedResults = JsonConvert.DeserializeObject<List<Group>>(r.ReadToEnd());
            }
            Assert.IsNotNull(expectedResults);

            // Are all result groups equal to the expected groups?
            for (int i = 0; i < testResults.Count; i++)
            {
                var testResult = testResults[i];
                var expectedResult = expectedResults[i];

                Assert.IsTrue(testResult.RecursivelyEquals(expectedResult));
            }
        }
    }
}
