﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>()
            { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = from fruit in fruits
                where fruit.StartsWith("L")
                select fruit;

            foreach (string L in LFruits)
            {
              //  Console.WriteLine($"{L}");
            }


            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 | number % 6 == 0);
            foreach( int number in fourSixMultiples)
            {
                //Console.WriteLine($"{number}");
            }

            // Output how many numbers are in this list
            List<int> numb = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
                //Console.WriteLine($"the list is: {numb.Count}");



                                //Ordering Operations
                // Order these student names alphabetically, in descending order (Z to A)
                     List<string> names = new List<string>()
                {
                    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                    "Francisco", "Tre"
                };

            List<string> descend = names.OrderByDescending(name => name.First()).ToList();
                //Console.WriteLine($"These student names alphabetically, in descending order is:");
                foreach (string name in descend)
            {
                //Console.WriteLine(name);
            }


            // Build a collection of these numbers sorted in ascending order
             List<int> numberss = new List<int>()
            {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            IEnumerable<int> ascenNumber = from count in numberss
                    orderby count ascending
                     select count;
                foreach(int c in ascenNumber)
            {
                //Console.WriteLine($"{c}");
            }


            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                 2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
                //Console.WriteLine($"the total money we made is : {purchases.Sum()}");


            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
                //Console.WriteLine($"our most expensive stuff is: {prices.Max()}");




                //Partitioning Operations
/*
    Store each number in the following List until a perfect square
    is detected.

    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
*/
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
             bool IsNumberSquare(int num)
            {
                int number = (int)Math.Sqrt(num);
                return num == number * number;
            }
            IEnumerable<int> squareNumbers = wheresSquaredo.TakeWhile(num => !IsNumberSquare(num));

            Console.WriteLine($"The perfect squere List detected is ");
            foreach (int num in squareNumbers)
            {
               // Console.WriteLine(num);
            };
            


             List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };
           IEnumerable<Bank> millionairesBanks = (
            from millionaire in customers
            group millionaire by millionaire.Bank into ListMillionaries
            select new Bank
            {
                Name = ListMillionaries.Key,
                MillionaireCount  = ListMillionaries.Where(count => count.Balance >= 1000000)
                .ToList().Count()
            });
            Console.WriteLine("Given the same customer set, display how many millionaires per bank.");
            foreach(Bank bank in millionairesBanks)
            {
                Console.WriteLine($"{bank.Name} {bank.MillionaireCount}");
            }

        }
    }
}
