class Program
{
    static readonly object lockObject = new object();

    static void Main(string[] args)
    {
        Thread thread1 = new Thread(CountSentences);
        thread1.Start("test.txt");

        Thread.Sleep(100);

        Thread thread2 = new Thread(ReplaceExclamation);
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("All threads have finished their work.");
    }

    static void CountSentences(object filePathObj)
    {
        string filePath = (string)filePathObj;

            string content;
            lock (lockObject)
            {
                if (!File.Exists(filePath))
                {                  
                    File.WriteAllText(filePath, string.Empty);
                }

                content = File.ReadAllText(filePath);
            Console.WriteLine("File upload successful.\n");
        }

            int count = CountSentences(content);
        Console.WriteLine("Number of sentences in the file: " + count);
        
    }

    static void ReplaceExclamation()
    {
        while (Thread.CurrentThread.ThreadState != ThreadState.WaitSleepJoin) { }

        string filePath = "test.txt";

        lock (lockObject)
        {
            string content = File.ReadAllText(filePath);
            content = content.Replace("!", "#");
            File.WriteAllText(filePath, content);
        }

        Console.WriteLine("Exclamation marks replaced with # in the file.");
    }

    static int CountSentences(string text)
    {
        int count = 0;
        foreach (char c in text)
        {
            if (c == '.' || c == '?' || c == '!')
            {
                count++;
            }
        }
        return count;
    }
}