class Event
{
    private string students{ get; }
    private string events { get; }
    public Event(string students, string events)
    {
        this.students = students;
        this.events = events;
    }
    public List<Student> ViewStudents()
    {
        List<Student> student = new List<Student>();
        if (!File.Exists("Students.txt"))
        {
            return student;
        }
        string[] lines = File.ReadAllLines("Students.txt");
        foreach (string line in lines)
        {
            string spaces = line.Trim(); //убираем лишние пробелы
            string[] nameAndGroup = spaces.Split(';');
            if (nameAndGroup.Length == 2)
            {
                string name = nameAndGroup[0].Trim();
                string group = nameAndGroup[1].Trim();
                if (name != "" && group != "")
                {
                    student.Add(new Student(name, group));
                }
            }
        }
        return student;
    }
    public Dictionary<string, List<Student>> StudentGroup(List<Student> students)
    {
        Dictionary<string, List<Student>> groups = new Dictionary<string, List<Student>>();
        foreach (Student student in students)
        {
            string group = student.Group;
            if (!groups.TryGetValue(group, out List<Student> undergrad))
            {
                undergrad = new List<Student>();
                groups[group] = undergrad;
            }
            undergrad.Add(student);
        }
        return groups;
    }
    public List<PastEvent> LastEvents()
    {
        List<PastEvent> lastEvents = new List<PastEvent>();
        if (!File.Exists("Events.txt"))
        {
            return lastEvents;
        }
        string[] lines = File.ReadAllLines("Events.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            DateTime date = DateTime.ParseExact(parts[0], "dd.MM.yyyy", null);//превращает строку в дату
            PastEvent et = new PastEvent();
            et.Date = date;
            string[] student = parts[2].Split(',');
            foreach (string students1 in student)
            {
                int open = students1.IndexOf('(');
                int close = students1.LastIndexOf(')');
                if (open > 0 && close > open)
                {
                    string name = students1.Substring(0, open).Trim(); //возвращает подстроку длиной 0, начиная с позиции open
                    string group = students1.Substring(open + 1, close - open - 1).Trim();
                    et.Member.Add(new Student(name, group));
                }
            }
            lastEvents.Add(et);
        }
        lastEvents.Sort(new SortingPastEvent());
        if (lastEvents.Count > 3)
        {
            lastEvents = lastEvents.GetRange(0, 3);
        }
        return lastEvents;
    }
    public List<Student> EventForStudent(Dictionary<string, List<Student>> groups, int countPerGroup)
    {
        List<PastEvent> lastEvents = LastEvents();
        List<string> participation = new List<string>();
        foreach (PastEvent et in lastEvents)
        {
            foreach (Student student in et.Member)
            {
                participation.Add(student.Name);
            }
        }
        List<Student> result = new List<Student>();
        Random random = new Random();
        foreach (string group in groups.Keys)
        {
            List<Student> members = groups[group];
            List<Student> notParticipation = new List<Student>();
            foreach (Student student in members)
            {
                if (!participation.Contains(student.Name))
                {
                    notParticipation.Add(student);
                }
            }
            List<Student> futureParticipant;
            if (notParticipation.Count > 0)
            {
                futureParticipant = notParticipation;
            }
            else
            {
                futureParticipant = members;
            }
            List<Student> temp = new List<Student>(futureParticipant);
            List<Student> member = new List<Student>();
            int need = Math.Min(countPerGroup, temp.Count);
            for (int i = 0; i < need; i++)
            {
                int idx = random.Next(temp.Count);
                member.Add(temp[idx]);
                temp.RemoveAt(idx);
            }
            result.AddRange(member);
        }
        return result;
    }
    public void StudentRegistration(DateTime date, string eventName, List<Student> participants)
    {
        using (StreamWriter writer = File.AppendText("Events.txt"))
        {
            writer.Write(date.ToString("dd.MM.yyyy"));
            writer.Write(";");
            writer.Write(eventName);
            writer.Write(";");

            for (int i = 0; i < participants.Count; i++)
            {
                if (i > 0) writer.Write(",");
                writer.Write(participants[i].Name + "(" + participants[i].Group + ")");
            }
            writer.WriteLine();
        }
    }
    public bool NumberGroups(Dictionary<string, List<Student>> groups)
    {
        return groups.Count >= 2;
    }
}
