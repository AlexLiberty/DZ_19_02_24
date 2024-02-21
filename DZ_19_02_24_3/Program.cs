
//3
List<int> numbers = new List<int> { 20, 30, 40, 50, 60 };

//Task task1 = Task.Run(() => DecrementValues(numbers));
//Task task2 = Task.Run(() => DecrementValues(numbers));
//Task task3 = Task.Run(() => DecrementValues(numbers));

//Task.WaitAll(task1, task2, task3);

//Console.WriteLine("Changed values:");
//foreach (int num in numbers)
//{
//    Console.WriteLine(num);
//}
//void DecrementValues(List<int> numbers)
//{
//    lock (numbers)
//    {
//        for (int i = 0; i < numbers.Count; i++)
//        {
//            numbers[i]--;
//        }
//    }
//}

//4
Task task1 = DecrementValuesAsync(numbers);
Task task2 = DecrementValuesAsync(numbers);
Task task3 = DecrementValuesAsync(numbers);

await Task.WhenAll(task1, task2, task3);

Console.WriteLine("Changed values:");
foreach (int num in numbers)
{
    Console.WriteLine(num);
}

async Task DecrementValuesAsync(List<int> numbers)
{
    await Task.Run(() =>
    {
        lock (numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] -= 5;
            }
        }
    });
}
