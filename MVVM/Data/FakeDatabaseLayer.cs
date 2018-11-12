using MvvmExample.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MvvmExample.Data
{
    class FakeDatabaseLayer
    {
        public static ObservableCollection<Person> GetPeopleFromDatabase()
        {
            return new ObservableCollection<Person>
            {
                new Person { FirstName="Nathan", LastName="WILCKE", Age=21 },
                new Person { FirstName="Adrien", LastName="Marini", Age=31 },
                new Person { FirstName="Steve", LastName="Bigleur", Age=60 },
            };
        }

        public static List<PocoPerson> GetPocoPeopleFromDatabase()
        {
            return new List<PocoPerson>
            {
                new PocoPerson { FirstName="Nathan", LastName="WILCKE", Age=21 },
                new PocoPerson { FirstName="Adrien", LastName="Marini", Age=31 },
                new PocoPerson { FirstName="Steve", LastName="Bigleur", Age=60 },
            };
        }
    }
}
