using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> queueSteel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> stackCarbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> swarsCount = new Dictionary<string, int>();
            
                   swarsCount.Add("Gladius", 0);
                   swarsCount.Add("Shamshir", 0);
                   swarsCount.Add("Katana", 0);
                   swarsCount.Add("Sabre", 0);
                   swarsCount.Add("Broadsword", 0);


            while (queueSteel.Count > 0 && stackCarbon.Count > 0)
            {
                if (queueSteel.Peek() + stackCarbon.Peek() == 70)
                {
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    swarsCount["Gladius"] += 1;
                   
                }
                else if (queueSteel.Peek() + stackCarbon.Peek() == 80)
                {
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    swarsCount["Shamshir"] += 1;
                }
                else if (queueSteel.Peek() + stackCarbon.Peek() == 90)
                {
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    swarsCount["Katana"] += 1;
                }
                else if (queueSteel.Peek() + stackCarbon.Peek() == 110)
                {
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    swarsCount["Sabre"] += 1;
                }
                else if (queueSteel.Peek() + stackCarbon.Peek() == 150)
                {
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    swarsCount["Broadsword"] += 1;
                }

                else 
               
                {
                    int currSteel = queueSteel.Dequeue();
                    int currCarbon = stackCarbon.Peek() + 5;
                    stackCarbon.Pop();
                    stackCarbon.Push(currCarbon);

                }
               
            }

            if (swarsCount.Any(x => x.Value > 0))
            {
                Console.WriteLine($"You have forged {swarsCount.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (queueSteel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", queueSteel)}");
            }
            if (stackCarbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", stackCarbon)}");
            }

            foreach (var item in swarsCount.OrderBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

        }
    }
}
