
//int[] array = new int[10];
//Random random = new Random();
//for(int i = 0; i < array.Length; i++)
//    array[i] = random.Next() % 100;

//foreach(int i in array)
//    Console.Write($"{i} ");
//Console.WriteLine();

//Array.Sort(array);

//foreach (int i in array)
//    Console.Write($"{i} ");
//Console.WriteLine();


Employee[] employees = new Employee[]
{
    new(){ Name = "Sammy", Age = 39 },
    new(){ Name = "Jimmy", Age = 42 },
    new(){ Name = "Tommy", Age = 21 },
    new(){ Name = "Billy", Age = 49 },
    new(){ Name = "Donny", Age = 31 },
};

foreach (var e in employees)
    Console.WriteLine(e);
Console.WriteLine();

Array.Sort(employees);

foreach (var e in employees)
    Console.WriteLine(e);




class Employee : IComparable<Employee> // IComparable
{
    public string Name { set; get; }
    public int Age { set; get; }

    public int CompareTo(Employee? other)
    {
        return this.Name.CompareTo(other.Name);
    }

    //public int CompareTo(object? obj)
    //{
    //    //return this.Name.CompareTo((obj as Employee).Name);
    //    return this.Age.CompareTo((obj as Employee).Age);
    //}

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}





