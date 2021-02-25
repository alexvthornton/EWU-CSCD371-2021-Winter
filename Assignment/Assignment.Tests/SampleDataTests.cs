using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Assignment.Tests
{

    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_ForEachCount_IteratesThroughCount()
        {
            var sampleData = new SampleData();

            Assert.AreEqual<int>(50, sampleData.CsvRows.Count());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_IsUnique()
        {
            var sampleData = new SampleData();

            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.IsTrue(Enumerable.SequenceEqual(states.Distinct(), states));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_IsSorted()
        {
            var statesList = new List<string>();
            var sampleData = new SampleData();

            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            foreach (string item in states)
            {
                // Compares the previous item, which is the last item in the hashset,
                // to the current item
                if(statesList.Count!=0 && item.CompareTo(statesList.Last()) < 0)
                {
                    Assert.Fail();
                }
                statesList.Add(item);
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
        public void People_EqualToExpectedPersonStrings()
        {
            var sampleData = new SampleData();

            const int StateColumn=6, CityColumn=5, ZipColumn=7, FirstNameColumn=1, LastNameColumn=2; 

            var people = sampleData.CsvRows.Select(line => line.Split(",")).OrderBy(line => line[StateColumn]).
                ThenBy(line => line[CityColumn]).ThenBy(line => line[ZipColumn]).
                Select( line => new string[] { line[StateColumn], line[CityColumn], line[ZipColumn], line[FirstNameColumn]+" "+line[LastNameColumn], line[3]}).Select(line => string.Join(", ", line));

            string expected = Environment.NewLine+string.Join(Environment.NewLine, people);

            // Uses Person.ToString()
            string result = sampleData.People.Aggregate("",(result,person) => result +Environment.NewLine + person);
            
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

    }
}
