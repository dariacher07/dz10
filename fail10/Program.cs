using System.Globalization;
class Program
{
    static void Main()
    {
        Console.WriteLine("Задача 1");
        Event et = new Event("Students.txt", "Events.txt");
        List<Student> students = et.ViewStudents();
        if (students.Count == 0)
        {
            Console.WriteLine("Студентов нет");
            return;
        }
        Dictionary<string, List<Student>> groups = et.StudentGroup(students);
        if (groups.Count < 2)
        {
            Console.WriteLine("Нужно больше 1 группы");
            return;
        }
        Console.WriteLine("Мероприятие: ");
        string name = Console.ReadLine();
        Console.WriteLine("Дата: ");
        string day = Console.ReadLine();
        DateTime eventDate;
        if (!DateTime.TryParseExact(day, "dd.MM.yyyy", null, DateTimeStyles.None, out eventDate))
        {
            Console.WriteLine("Ошибка: дата должна быть в формате дд.мм.гггг");
            return;
        }
        Console.WriteLine("Количество: ");
        string gp = Console.ReadLine();
        int count;
        if (!int.TryParse(gp, out count) || count <= 0)
        {
            Console.WriteLine("Введите число");
            return;
        }
        List<Student> chosen = et.EventForStudent(groups, count);
        et.StudentRegistration(eventDate, name, chosen);
        Console.WriteLine("Участники:");
        foreach (Student student in chosen)
            Console.WriteLine(student.Name + student.Group);
        Console.WriteLine("Задача 2");
        Events events = new Events(new List<Person>
        {
            new Person("Василиса", "Танцы хип-хоп", " Бегу на танцы!"),
            new Person("Агния", "Егор Крид", " Я хочу за него замуж!!!"),
            new Person("Гермиона", "Книги", " Вышло продолжение моей любой истории!")
        });
        List<string> doings = events.Hobby();
        Console.WriteLine("События:");
        for (int i = 0; i < doings.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + doings[i]);
        }
        Console.Write("Введите событие: ");
        string input = Console.ReadLine();
        string doingsEvent;
        int number;
        bool isNumber = int.TryParse(input, out number);

        if (isNumber && number >= 1 && number <= doings.Count)
        {
            doingsEvent = doings[number - 1];
        }
        else
        {
            doingsEvent = input;
        }
        List<Person> interestedPeople = events.Reaction(doingsEvent);
        if (interestedPeople.Count == 0)
        {
            Console.WriteLine("Нет людей");
        }
        else
        {
            foreach (Person people in interestedPeople)
            {
                Console.WriteLine(people.Name +  people.Reaction);
            }
        }
    }
}
        
    


