using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Assignment.Tests
{

    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void CsvRows_ForEach_IteratesThroughData()
        {
            var sampleData = new SampleData();
            int result = 0;
            foreach(string item in sampleData.CsvRows)
            {
                result++;
            }

            Assert.AreEqual<int>(50, result);

        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_IsUnique()
        {
            // Using a hashset so as only to iterate once through CsvRows
            // by adding each item from CsvRows to a hashset.
            var statesSet = new HashSet<string>();
            var sampleData = new SampleData();

            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            foreach (string item in states)
            {
                if (!statesSet.Add(item))
                    Assert.Fail();
            }
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_IsSorted()
        {
            // Using a hashset so as only to iterate once through CsvRows
            // by adding each item from CsvRows to a hashset.
            var statesSet = new HashSet<string>();
            var sampleData = new SampleData();

            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            foreach (string item in states)
            {
                // Compares the previous item, which is the last item in the hashset,
                // to the current item
                if(statesSet.Count!=0 && item.CompareTo(statesSet.Last()) < 0)
                    Assert.Fail();
                statesSet.Add(item);
            }
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_EqualsJoinGetUniqueSortedListOfStatesGivenCsvRows()
        {
            var sampleData = new SampleData();
            string? result = null;
            foreach(string item in sampleData.GetUniqueSortedListOfStatesGivenCsvRows())
            {
                if(result == null)
                {
                    result = item;
                }
                else
                {
                    result = string.Join(", ", result, item);
                }
            }
            Assert.AreEqual<string>(result!, sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
        }

        [TestMethod]
        public void People_EqualToExpectedPersonString()
        {
            var sampleData = new SampleData();
            string result = "\n", expected = "\n";

            var people = sampleData.CsvRows.Select(line => line.Split(",")).OrderBy(line => line[6]).
                ThenBy(line => line[5]).ThenBy(line => line[7]).
                Select( line => new string[] { line[6], line[5], line[7], line[1]+" "+line[2], line[3]}).Select(line => string.Join(", ", line));

            foreach (string line in people)
            {
                expected += line + "\n";
            }

            foreach (Person item in sampleData.People)
            {
                result += PersonToString(item) + "\n";
            }

            Assert.AreEqual<string>(expected, result);
        }

        [TestMethod]
        public void FilterByEmailAddress_GivenExistentEmail_ReturnsFirstLastName()
        {
            var sampleData = new SampleData();
            string result = "";

            Predicate<string> filter = (string str) => { return str == "atoall@fema.gov"; };

            foreach ((string FirstName, string LastName) item in sampleData.FilterByEmailAddress(filter))
            {
                result += item.FirstName + " " + item.LastName;
            }

            Assert.AreEqual<string>("Amelia Toal", result);
        }

        [TestMethod]
        public void FilterByEmailAddress_GivenNonExistentEmail_ReturnsEmptyIEnumerable()
        {
            var sampleData = new SampleData();

            Predicate<string> filter = (string str) => { return str == "test@test.gov"; };

            Assert.IsTrue(!sampleData.FilterByEmailAddress(filter).Any());
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_EqualsExpectedString()
        {
            var sampleData = new SampleData();

            string expected = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

            Assert.AreEqual<string>(expected, result);
        }

        private string PersonToString(Person person)
        {
            return $"{person.Address.State}, {person.Address.City}, {person.Address.Zip}, {person.FirstName} {person.LastName}, {person.EmailAddress}";
        }

    }
}
