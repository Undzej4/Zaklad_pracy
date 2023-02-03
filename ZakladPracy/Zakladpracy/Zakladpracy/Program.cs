using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeApp
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public double HourlyRate { get; set; }

        public Employee(int id, string firstName, string lastName, DateTime dob, string position, double hourlyRate = 0, double salary = 0)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            Position = position;
            Salary = salary;
            HourlyRate = hourlyRate;
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            employees.Add(new Employee(1, "Jan", "Nowak", new DateTime(2002, 03, 04), "Pracownik fizyczny", 18.5, 0));
            employees.Add(new Employee(2, "Agnieszka", "Kowalska", new DateTime(1973, 12, 15), "Urzędnik", 0, 2800));
            employees.Add(new Employee(3, "Robert", "Lewandowski", new DateTime(1980, 1, 29), "Pracownik fizyczny", 48.0, 0));
            employees.Add(new Employee(4, "Zofia", "Płucińska", new DateTime(1998, 2, 15), "Urzędnik", 0, 4750));
            employees.Add(new Employee(5, "Grzegorz", "Braun", new DateTime(1980, 1, 28), "Pracownik fizyczny", 48, 0));
            while (true)
            {
                Console.WriteLine("WYBIERZ OPCJĘ: ");
                Console.WriteLine("1 => LISTA WSZYSTKICH PRACOWNIKÓW");
                Console.WriteLine("2 => WYLICZ PENSJĘ PRACOWNIKA");
                Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
                Console.WriteLine();
                Console.Write("WYVBIERZ 1, 2 LUB 3: ");

                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Console.Clear();
                    DisplayEmployeeList();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    CalculateSalary();

                }
                else if (option == 3)
                {
                    break;
                }
            }
        }

        static void DisplayEmployeeList()
        {
            Console.WriteLine("Id\tImię\tNazwisko\tData urodzenia\tStanowisko");

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Id + "\t" + employee.FirstName + "\t" + employee.LastName + "\t" + employee.DateOfBirth.ToShortDateString() + "\t" + employee.Position);
            }
        }

        static void CalculateSalary()
        {

            Console.WriteLine("PROSZĘ PODAĆ ID PORACOWNIKA DLA KTÓREGO ZOSTANIE WYLICZONE WYNAGRODZENIA: ");
            int id = int.Parse(Console.ReadLine());


            var employee = employees.Find(e => e.Id == id);

            if (employee == null)
            {
                Console.Clear();
                Console.WriteLine("BRAK PRACOWNIKA O PODANYM ID");

                return;
            }
            int age = (DateTime.Now.Year - employee.DateOfBirth.Year);
            Console.Clear();
            if (employee.Salary == 0)
            {
                Console.WriteLine("WYLICZENIE WYNAGRODZENIA PRACOWNIKA");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("DANE PRACOWNIKA: ");
                Console.WriteLine("IMIĘ: i NAZWISKO: " + employee.FirstName + " " + employee.LastName);
                Console.WriteLine("WIEK: " + age + " lat");
                Console.WriteLine("STANOWISKO: " + employee.Position);
                Console.WriteLine("STAWKA GODZINOWA: " + employee.HourlyRate + " ZŁ/H");

            }
            else
            {
                Console.WriteLine("WYLICZENIE WYNAGRODZENIA PRACOWNIKA");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("DANE PRACOWNIKA: ");
                Console.WriteLine("IMIĘ: i NAZWISKO: " + employee.FirstName + " " + employee.LastName);
                Console.WriteLine("WIEK: " + age + " lat");
                Console.WriteLine("STANOWISKO: " + employee.Position);
                Console.WriteLine("PENSJA STAŁA: " + employee.Salary + " ZŁ");
            }

            Console.WriteLine("PROSZĘ PODAĆ ILOŚĆ PRZEPRACOWANYCH DNI PRZEZ PRACOWNIKA(MAX.20): ");
            int days = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("PROSZĘ PODAĆ KWOTĘ PREMII DLA PRACOWNIKA: ");
            int bonus = int.Parse(Console.ReadLine());
            Console.Clear();

            double baseSalary = employee.Salary;
            if (employee.Position == "Urzędnik")
            {
                baseSalary = days == 20 ? employee.Salary : 0.8 * employee.Salary;
            }
            else if (employee.Position == "Pracownik fizyczny")
            {
                baseSalary = days * employee.HourlyRate * 8;
            }
            double tax = 0;

            if (age > 26)
            {
                tax = 0.18 * (baseSalary + bonus);
            }

            double grossSalary = Math.Round(baseSalary + bonus - tax);
            double salary = Math.Round(baseSalary + bonus);
            double hourlyrate1 = Math.Round(employee.Salary + bonus);

            Console.Clear();
            Console.WriteLine("WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: " + salary);

            if (employee.HourlyRate == 0)
            {

                Console.WriteLine("POTRĄCONY PODATEK: " + Math.Round(tax));


            }
            else if (employee.Salary == 0)
            {

                Console.WriteLine("POTRĄCONY PODATEK: " + Math.Round(tax));

            }
            Console.WriteLine("DO WYPŁATY: " + grossSalary);
            

        }



    }


}
