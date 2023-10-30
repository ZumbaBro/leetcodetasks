using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmTasks
{
    public static class AnyAlgoritms
    {
        /// <summary>
        /// Find frequent letter, and show count
        /// </summary>
        public static void FindFrequentLetter()
        {
            var str = Console.ReadLine();
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!dict.ContainsKey(str[i]))
                {
                    dict.Add(str[i],1);
                }
                else
                {
                    dict[str[i]] = dict[str[i]] + 1;
                }
            }

            int maxValue = dict.Max(x => x.Value);
            var result = dict.Where(x => x.Value == maxValue);
            foreach (var item in result)
            {
                Console.WriteLine($"Letter- {item.Key}: Count-{item.Value}");
            }
        }
    }
}
