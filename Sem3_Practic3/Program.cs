using Sem3_Alaba1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Sem3_Practic3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            //Task2();
            //Task3();
            //Task4();
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
            arrayList.Add(14.1);

            Console.WriteLine($"Count: {arrayList.Count}");
            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine(arrayList[i]);
            }

            Console.WriteLine("\nEnter the item you want to find:");
            string itemInList = Console.ReadLine();
            int itemInListInt;
            double itemInListDouble;
            if (int.TryParse(itemInList, out itemInListInt))
            {
                Console.WriteLine(arrayList.Contains(itemInListInt));
            }
            else if(double.TryParse(itemInList, out itemInListDouble))
            {
                Console.WriteLine(arrayList.Contains(itemInListDouble));
            }
            else
            {
                Console.WriteLine(arrayList.Contains(itemInList));
            }
        }

        static void Task2()
        {

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(11);
            queue.Enqueue(2);
            queue.Enqueue(32);
            queue.Enqueue(4);
            queue.Enqueue(15);
            queue.Enqueue(54);
            queue.Enqueue(8);

            int n = 2;
            for (int i = 0; i < n; i++)
            {
                queue.Dequeue();
            }

            queue.Enqueue(82);
            List<int> list = new List<int>(queue.ToList());

            Console.WriteLine("Items in list:");
            foreach (var item in list)
            {
                Console.Write(item + "\n");
            }

            Console.WriteLine("\nEnter the item you want to find:");
            int itemInList = Convert.ToInt32(Console.ReadLine());

            if (list.Contains(itemInList))
            {
                Console.WriteLine("Item in list");
            }
            else
            {
                Console.WriteLine("No item in list");
            }
        }

        static void Task3()
        {
            Queue<ComputerDevice> queue = new Queue<ComputerDevice>();
            queue.Enqueue(new ComputerDevice());
            queue.Enqueue(new ComputerDevice("Samsung", "Galaxy S20", 2017, 500));
            queue.Enqueue(new ComputerDevice("Apple", "IPhone 15 Pro", 2022, 1000));
            queue.Enqueue(new ComputerDevice("Xiaomi", "Redmi Note 12", 2023, 250));
            queue.Enqueue(new ComputerDevice("Huawei", "Honor 10i", 2017, 150));

            int n = 2;
            for (int i = 0; i < n; i++)
            {
                queue.Dequeue();
            }

            queue.Enqueue(new ComputerDevice("Apple", "Macbook", 2018, 1500));
            List<ComputerDevice> list = new List<ComputerDevice>(queue.ToList());

            Console.WriteLine("Items in list:");
            foreach (var item in list)
            {
                Console.WriteLine(item.Info());
            }

            Console.WriteLine("Enter the model of item you want to find:");
            string itemInList = Convert.ToString(Console.ReadLine());

            if (list.Exists(x => x.Model.ToLower() == itemInList.ToLower()))
            {
                Console.WriteLine("\nThe found item:");
                Console.WriteLine(list.Find(x => x.Model.ToLower() == itemInList.ToLower()).Info());
            }
            else
            {
                Console.WriteLine("No item in list");
            }

            list.Sort(); // сортировка проводится с помощью метода CompareTo() интерфейса IComparable
            Console.Write("Checking the method ");
            ConsoleColor.Yellow.Write("CompareTo()\n");
            Console.WriteLine("Price of items in list:");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Price}$");
            }

            Console.Write("\nChecking the method ");
            ConsoleColor.Yellow.Write("Clone()\n");
            ComputerDevice device = (ComputerDevice)list[0].Clone();
            Console.WriteLine($"Original object:\n{list[0].Info()}\nCopied object:\n{device.Info()}");
        }

        static void Task4()
        {
            var computerDevices = new ObservableCollection<ComputerDevice>
            {
                new ComputerDevice("Samsung", "Galaxy S20", 2017, 500),
                new ComputerDevice("Apple", "IPhone 15 Pro", 2022, 1000)
            };
            computerDevices.CollectionChanged += ComputerDevice_CollectionChanged;

            Console.WriteLine("Items in observable collection:");
            foreach (var item in computerDevices)
            {
                Console.WriteLine(item.Info());
            }

            computerDevices.Add(new ComputerDevice("Xiaomi", "Redmi Note 12", 2023, 250));
            computerDevices.RemoveAt(0);
            computerDevices[0] = new ComputerDevice("Huawei", "Honor 10i", 2017, 150);

            Console.WriteLine("\nItems in observable collection:");
            foreach (var item in computerDevices)
            {
                Console.WriteLine(item.Info());
            }
        }

        static void ComputerDevice_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is ComputerDevice newComputerDevice)
                        Console.WriteLine($"Добавлен новый объект: {newComputerDevice.Brand} {newComputerDevice.Model}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is ComputerDevice oldComputerDevice)
                        Console.WriteLine($"Удален объект: {oldComputerDevice.Brand} {oldComputerDevice.Model}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    if ((e.NewItems?[0] is ComputerDevice replacingComputerDevice) &&
                        (e.OldItems?[0] is ComputerDevice replacedComputerDevice))
                        Console.WriteLine($"Объект {replacedComputerDevice.Brand} {replacedComputerDevice.Model} " +
                            $"заменен объектом {replacingComputerDevice.Brand} {replacingComputerDevice.Model}");
                    break;
            }

        }
    }
}
