using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerableAndIEnumeratorDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DogShelter shelter = new DogShelter();

            foreach (Dog dog in shelter)
            {
                if (!dog.IsNaughtyDog)
                {
                    dog.GiveTreat(2);
                }
                else
                {
                    dog.GiveTreat(1);
                }
            }

            IEnumerable<int> unknownCollection;
            unknownCollection = GetCollection(1);

            Console.WriteLine("This was a List<int>");
            foreach (int num in unknownCollection)
            {
                Console.Write(num + " ");
            }

            unknownCollection = GetCollection(2);
            Console.WriteLine("\nThis was a Queue<int>");
            foreach (int num in unknownCollection)
            {
                Console.Write(num + " ");
            }

            unknownCollection = GetCollection(5);
            Console.WriteLine("\nThis was an array of int");
            foreach (int num in unknownCollection)
            {
                Console.Write(num + " ");
            }

            List<int> numberList = new List<int> { 9, 2, 3 };

            int[] numberArray = new int[] {1, 7, 3, 8, 6 };

            Console.WriteLine(" ");

            CollectionSum(numberList);

            CollectionSum(numberArray);

            PhoneBook MyPhoneBook = new PhoneBook();

            foreach (Contact contact in MyPhoneBook)
            {
                contact.Call();
            }
        }


        static void CollectionSum(IEnumerable<int> anyCollection)
        {
            int sum = 0;
            foreach (int num in anyCollection)
            {
                sum += num;
            }

            Console.WriteLine("\nSum is {0}", sum);
        }

        static IEnumerable<int> GetCollection(int option)
        {
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5 };

            Queue<int> numbersQueue = new Queue<int>();
            numbersQueue.Enqueue(6);
            numbersQueue.Enqueue(7);
            numbersQueue.Enqueue(8);
            numbersQueue.Enqueue(9);
            numbersQueue.Enqueue(10);

            if (option == 1)
            {
                return numberList;
            }
            else if (option == 2)
            {
                return numbersQueue;
            }
            else
            {
                return new int[] {11, 12, 13, 14, 15};
            }

        }
    }


    class Dog
    {
        public string Name { get; set; }
        public bool IsNaughtyDog { get; set; }
        public Dog(string name, bool isNaughtyDog)
        {
            Name = name;
            IsNaughtyDog = isNaughtyDog;
        }

        public void GiveTreat(int numberOfTreats)
        {
            Console.WriteLine("Dog: {0} said wuoff {1} times!.", Name, numberOfTreats);
        }
    }

    class DogShelter : IEnumerable<Dog>
    {
        public List<Dog> dogs;

        public DogShelter()
        {
            dogs = new List<Dog>()
            {
                new Dog("Casper", false),
                new Dog("Sif", true),
                new Dog("Oreo", false),
                new Dog("Pixel", false),
            };
        }

        IEnumerator<Dog> IEnumerable<Dog>.GetEnumerator()
        {
            return dogs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    public class PhoneBook : IEnumerable<Contact>
    {

        public List<Contact> Contacts;

        public PhoneBook()
        {
            Contacts = new List<Contact>(){
                new Contact("Andre", "435797087"),
                new Contact("Lisa", "435677087"),
                new Contact("Dine", "3457697087"),
                new Contact("Sofi", "4367697087")
            };
        }

        IEnumerator<Contact> IEnumerable<Contact>.GetEnumerator()
        {
            return Contacts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }

    public class Contact
    {

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public Contact(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public void Call()
        {
            Console.WriteLine("Calling to {0}. Phone number is {1}", Name, PhoneNumber);
        }
    }
}
