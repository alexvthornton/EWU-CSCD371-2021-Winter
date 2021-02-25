using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {

        private const int FirstNameColumn = 1;
        private const int LastNameColumn = 2;
        private const int EmailColumn = 3;
        private const int StreetAddressColumn = 4;
        private const int CityColumn = 5;
        private const int StateColumn = 6;
        private const int ZipColumn = 7;

        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.FullName, "Assignment" , "People.csv")).Skip(1);


        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() => CsvRows.Select(line=>line.Split(",")[StateColumn]).Distinct().OrderBy(state=>state);


        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows() =>  GetUniqueSortedListOfStatesGivenCsvRows().Aggregate((result, item) => result + ", " + item);


        // 4.
        // Ordered by State, City, ZipCode
        public IEnumerable<IPerson> People => CsvRows.Select(line => line.Split(",")).OrderBy(line => line[StateColumn]).ThenBy(line => line[CityColumn]).ThenBy(line => line[ZipColumn])
            .Select(person => new Person(person[FirstNameColumn], person[LastNameColumn], new Address(person[StreetAddressColumn], person[CityColumn], person[StateColumn], person[ZipColumn]), person[EmailColumn]));


        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) => People.Where(item => filter(item.EmailAddress)).Select(item => (item.FirstName, item.LastName));


        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
                IEnumerable<IPerson> people) => people.Select(item => item.Address.State).Distinct().Aggregate((result, item) => result + ", " + item);
    }
}
