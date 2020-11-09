using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helpers;

namespace UnitTest_search_fight
{
    [TestClass]
    public class ProgramUnitTest
    {
        [TestMethod]
        public void splitTerms_Case1_Test()
        {
            string input_string = "google python c#";
            List<string> input_splitted = ValidationHelper.splitTerms(input_string);

            List<string> spplited_expected = new List<string>()
            {
              "google",
              "python",
              "c#"
            };

            for (var i = 0; i < spplited_expected.Count; i++)
            {
                Assert.AreEqual(spplited_expected[i], input_splitted[i]);
            }

        }

        [TestMethod]
        public void splitTerms_Case2_Test()
        {
            string input_string = "google \"java script v2019\" c#";
            List<string> input_splitted = ValidationHelper.splitTerms(input_string);

            List<string> spplited_expected = new List<string>()
            {
              "google",
              "java script v2019",
              "c#"
            };

            for (var i = 0; i < spplited_expected.Count; i++)
            {
                Assert.AreEqual(spplited_expected[i], input_splitted[i]);
            }

        }

        [TestMethod]
        public void splitTerms_Case3_Test()
        {
            string input_string = "javascript bing \"node js v2019";
            List<string> input_splitted = ValidationHelper.splitTerms(input_string);

            List<string> spplited_expected = new List<string>()
            {
              "javascript",
              "bing",
              "node js v2019"
            };

            for (var i = 0; i < spplited_expected.Count; i++)
            {
                Assert.AreEqual(spplited_expected[i], input_splitted[i]);
            }

        }
    }
}
