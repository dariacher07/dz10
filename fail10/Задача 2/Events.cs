class Events
{
    private List<Person> person;

    public Events(List<Person> person)
    {
        if (person == null)
        {
            throw new ArgumentNullException();
        }
        this.person = person;
    }
    public List<string> Hobby()
    {
        List<string> interest = new List<string>();
        foreach (Person people in person)
        {
            bool temp = false;
            foreach (string hobby in interest)
            {
                if (hobby == people.Hobby)
                {
                    temp = true;
                    break;
                }
            }
            if (!temp)
            {
                interest.Add(people.Hobby);
            }
        }
        return interest;
    }
    public List<Person> Reaction(string events)
    {
        List<Person> result = new List<Person>();

        if (string.IsNullOrWhiteSpace(events))
        {
            return result;
        }
        foreach (Person people in person)
        {
            if (string.Equals(people.Hobby, events))
            {
                result.Add(people);
            }
        }
        return result;
    }
}
