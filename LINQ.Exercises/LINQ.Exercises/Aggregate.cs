using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LINQ.Exercises
{
    /// <summary>
    /// Your task is to apply LINQ `Count/Sum/Min/Max/Average/Aggregate` methods, so all tests will be passed.
    /// Make sure to preview test data located in TestData.cs file.
    /// Don't modify assertions or test data, all you need to do is to apply LINQ method so `result` variable will have expected value(s).
	
	
    /// </summary>
    [TestClass]
    public class Aggregate
    {
        [TestMethod]
        public void Count_all_numbers()
        {
            // First test is solved to show you how to use these exercises.
            int result = TestData.Numbers.Count();

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Count_all_occurences_of_1()
        {
            int result = TestData.Numbers.Count(n => n == 1);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Count_all_animals_having_character_count_equal_to_5()
        {
            // Hint: use nested count
            int result = TestData.Animals.Count(a => a.Length == 5);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Sum_all_numbers()
        {
            int result = TestData.Numbers.Sum();

            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void Sum_all_characters_in_animal_names()
        {
            // version 1
            //int result = TestData.Animals.Select(a=>a.Length).Sum();
            // version 2
            int result = TestData.Animals.Sum(a=>a.Count());

            Assert.AreEqual(38, result);
        }

        [TestMethod]
        public void Sum_all_birth_years()
        {
            // version 1
            //int result = TestData.People.Select(y=>y.Born.Year).Sum();
            // version 2
            int result = TestData.People.Sum(y => y.Born.Year);

            Assert.AreEqual(7915, result);
        }

        [TestMethod]
        public void Find_minimum_number()
        {
            int result = TestData.Numbers.Min();

            Assert.AreEqual(-5, result);
        }

        [TestMethod]
        public void Find_length_of_shortest_animal_name()
        {
            // version 1
            //int result = TestData.Animals.Select(n=>n.Length).Min();
            // version 2
            int result = TestData.Animals.Min(n => n.Length);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Find_earliest_birthday()
        {
            // version 1
            //DateTime result = TestData.People.OrderBy(a=>a.Born).First();
            // version 2
            DateTime result = TestData.People.Min(a => a.Born);

            Assert.AreEqual(new DateTime(1950, 12, 1), result);
        }

        [TestMethod]
        public void Find_maximum_number()
        {
            int result = TestData.Numbers.Max();

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Find_length_of_longest_animal_name()
        {
            // version 1
            //int result = TestData.Animals.Select(n => n.Length).Max();
            //version 2
            int result = TestData.Animals.Max(n => n.Length);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Find_latest_birthday()
        {
            // version 1
            //DateTime result = TestData.People.OrderByDescending(a=>a.Born).First().Born;
            // version 2
            DateTime result = TestData.People.Max(a => a.Born);

            Assert.AreEqual(new DateTime(2001, 5, 21), result);
        }

        [TestMethod]
        public void Find_average_of_numbers()
        {
            double result = TestData.Numbers.Average();

            Assert.AreEqual(-0.2, result);
        }

        [TestMethod]
        public void Find_average_of_birth_years()
        {
            // version 1
            //double result = TestData.People.Select(p=>p.Born.Year).Average();
            // version 2
            double result = TestData.People.Average(p => p.Born.Year);


            Assert.AreEqual(1978.75, result);
        }

        [TestMethod]
        public void Aggregate_Sum_of_all_numbers()
        {
            // Aggregate is a little bit more complicated
            // so first test is solved to show you how to use it.
            int result = TestData.Numbers.Aggregate((sum, nextValue) => sum + nextValue);

            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void Aggregate_Product_of_all_numbers()
        {
            // Hint: product is a result of multiplication
            int result = TestData.Numbers.Aggregate((product, nextValue) => product * nextValue);

            Assert.AreEqual(-1800, result);
        }

        [TestMethod]
        public void Aggregate_Secret_formula()
        {
            // secret formula is as follows
            // start with 256
            // for each person take the day of her/his birth date
            // if this day is bigger than 15, then substract 10 from it
            // else add 5 to it
            // and add resulting number to your aggregate
            int result = TestData.People.Aggregate(256, (sum, person) => sum + (person.Born.Day > 15 ? (person.Born.Day - 10) : (person.Born.Day + 5)));

            Assert.AreEqual(296, result);
        }
    }
}