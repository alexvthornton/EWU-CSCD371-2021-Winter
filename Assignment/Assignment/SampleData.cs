using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {

        private const int idColumnNumber = 0;
        private const int firstNameColumnNumber = 1;
        private const int lastNameColumnNumber = 2;
        private const int emailColumnNumber = 3;
        private const int streetAddressColumnNumber = 4;
        private const int cityColumnNumber = 5;
        private const int stateColumnNumber = 6;
        private const int zipColumnNumber = 7;
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.FullName, "Assignment" , "People.csv")).Skip(1);


        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() => CsvRows.Select(line=>line.Split(",")[stateColumnNumber]).Distinct().OrderBy(state=>state);


        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows() => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());


        // 4.
        // Ordered by State, City, ZipCode
        public IEnumerable<IPerson> People => CsvRows.Select(line => line.Split(",")).OrderBy(line => line[stateColumnNumber]).ThenBy(line => line[cityColumnNumber]).ThenBy(line => line[zipColumnNumber])
            .Select(person => new Person(person[firstNameColumnNumber], person[lastNameColumnNumber], new Address(person[streetAddressColumnNumber], person[cityColumnNumber], person[stateColumnNumber], person[zipColumnNumber]), person[emailColumnNumber]));


        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) => People.Where(item => filter(item.EmailAddress)).Select(item => (item.FirstName, item.LastName));


        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
                IEnumerable<IPerson> people) => people.Select(item => item.Address.State).Distinct().Aggregate((state, item) => state + ", " + item);
    }
}
