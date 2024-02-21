
int[] data;

    object dataLock = new object();

    void SortData()
    {
        Console.WriteLine("Task1: Start sorting data.");
        lock (dataLock)
        {
            Array.Sort(data);
        }
        Console.WriteLine("Task1: Data sorted: " + string.Join(", ", data));
        Console.WriteLine("Task1: Finishing data sorting");
    }

    void SearchNumber(int number)
    {
        Console.WriteLine("Task2: Finding a number " + number + " in data");
        bool found = false;
        lock (dataLock)
        {
            found = data.Contains(number);
        }
        if (found)
        {
            Console.WriteLine("Task2: Number " + number + " found in data");
        }
        else
        {
            Console.WriteLine("Task2: Number " + number + " not found in data");
        }
    }

data = new int[] { 3, 7, 1, 5, 9, 2, 8, 4, 6 };

int searchedNumber = 5;

Task task1 = Task.Run(() => SortData());
Task task2 = Task.Run(() => SearchNumber(searchedNumber));

Task.WaitAll(task1, task2);

Console.WriteLine("The main thread has finished running.");
   
