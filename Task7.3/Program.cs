using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    {
        private List<Sick> _sicks = new List<Sick>();
        private IEnumerable<Sick> _sortedSicks;

        public Hospital()
        {
            AddSicks();
        }

        public void Work()
        {
            bool isWork = true;
            Console.WriteLine("База данных больницы.");

            while (isWork)
            {
                Console.WriteLine("1.Вывести всех больных. \n2.Отсортировать больных. \n3.Выход. \nВыберите вариант:");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        ShowSicks();
                        break;
                    case "2":
                        SortSicksByCertainParameter();
                        break;
                    case "3":
                        isWork = false;
                        break;
                }

                WriteMessage();
            }
        }

        private void ShowSicks()
        {
            Console.Clear();
            foreach (Sick sick in _sicks)
                sick.ShowInfo();
        }

        private void SortSicksByCertainParameter()
        {
            Console.Clear();
            Console.WriteLine("1.Отсортировать по имени алфавиту. \n2.Отсортировать по возрасту. \n3.Вывести больных с определенной болезнью. \nВыберите вариант:");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    _sortedSicks = _sicks.OrderBy(sick => sick.Name);
                    break;
                case "2":
                    _sortedSicks = _sicks.OrderBy(sick => sick.Age);
                    break;
                case "3":
                    ShowSicksWithCertainDisease();
                    break;
                default:
                    Console.WriteLine("Ошибка ввода данных!");
                    break;
            }

            ShowSortedSicks();
            WriteMessage();
        }

        private void ShowSicksWithCertainDisease()
        {
            Console.WriteLine("Введите название болезни:");
            string userInput = Console.ReadLine();
            _sortedSicks = _sicks.Where(sick => sick.Disease == userInput);
        }

        private void ShowSortedSicks()
        {
            if (_sortedSicks.Count() > 0)
            {
                Console.Clear();
                foreach (Sick sortedSick in _sortedSicks)
                    sortedSick.ShowInfo();
            }
            else
            {
                Console.WriteLine("Больные не найдены!");
            }
        }

        private void AddSicks()
        {
            Random random = new Random();
            int maxValueOfAge = 100;
            int minCountOfSicks = 10;
            int maxCountOfSicks = 20;
            int countOfSicks = random.Next(minCountOfSicks, maxCountOfSicks);

            for (int i = 0; i < countOfSicks; i++)
            {
                int age = random.Next(maxValueOfAge);
                _sicks.Add(new Sick(SetNameOfSick(i), age, SetDiseaseOfSick(random)));
            }
        }

        private string SetNameOfSick(int numberOfName)
        {
            List<string> namesOfSicks = new List<string>
            {
            "Анна",
            "Святослав",
            "Марк",
            "Вероника",
            "Матвей",
            "Элина",
            "Таисия",
            "Антон",
            "Арина",
            "Александр",
            "Сафия",
            "Никита",
            "Елизавета",
            "Кира",
            "София",
            "Олег",
            "Марианна",
            "Варвара",
            "Юрий",
            "Георгий"
            };
            string name = namesOfSicks[numberOfName];
            return name;
        }

        private string SetDiseaseOfSick(Random random)
        {
            List<string> diseasesOfSicks = new List<string>
            {
            "туберкулез",
            "простуда",
            "малярия",
            "инсульт",
            "диабет",
            "артрит",
            "грипп",
            "спид",
            "рак",
            };
            int numberOfDisease = random.Next(diseasesOfSicks.Count);
            string disease = diseasesOfSicks[numberOfDisease];
            return (disease);
        }

        private void WriteMessage()
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу:");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Sick
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Sick(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}. Возраст: {Age}. Болезнь: {Disease}.");
        }
    }
}
