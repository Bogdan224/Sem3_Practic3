using System.Collections;

namespace Sem3_Practic3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
        }

        static void Task1()
        {
            ArrayList arrayList = new ArrayList();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                arrayList.Add(random.Next(0, 100));
            }
            arrayList.Add("Hello World");
            arrayList.RemoveAt(0);
            arrayList.Add(15);

            Console.WriteLine("Кол-во элементов: " + arrayList.Count);
            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine(arrayList[i]);
            }

            Console.WriteLine(arrayList.Contains(70));
        }

        static void Task2()
        {

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            int n = 3;
            for (int i = 0; i < n; i++)
            {
                queue.Dequeue();
            }
            List<int> list = queue.ToList();
            
        }
    }
}
