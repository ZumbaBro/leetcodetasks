using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmTasks
{
    public static class LeetcodeTasks
    {
        #region https://leetcode.com/problems/substring-with-concatenation-of-all-words/

        public static IList<int> FindSubstring(string s, string[] words)
        {
            if (s == null || words == null || s.Length < 1 || words.Length < 1 || words.First().Length < 1)
                return new List<int>();
            if (words.Length * words.First().Length > s.Length)
                return new List<int>();



            return null;
        }

        public static List<string> SubstringsOfWords(string[] words)
        {
            foreach (var item in words)
            {

            }
            return null;
        }

        static List<int> FindSubstringIndices(string s, string[] words)
        {
            List<int> result = new List<int>();
            if (string.IsNullOrEmpty(s) || words.Length == 0)
                return result;

            int wordLength = words[0].Length;
            int totalWords = words.Length;
            var wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordsCount.ContainsKey(word))
                    wordsCount[word]++;
                else
                    wordsCount[word] = 1;
            }

            for (int i = 0; i < wordLength; i++)
            {
                int left = i, right = i, count = 0;
                var currentWords = new Dictionary<string, int>();

                while (right + wordLength <= s.Length)
                {
                    string word = s.Substring(right, wordLength);

                    if (wordsCount.ContainsKey(word))
                    {
                        if (currentWords.ContainsKey(word))
                            currentWords[word]++;
                        else
                            currentWords[word] = 1;

                        count++;

                        while (currentWords[word] > wordsCount[word])
                        {
                            string leftWord = s.Substring(left, wordLength);
                            currentWords[leftWord]--;
                            count--;
                            left += wordLength;
                        }

                        if (count == totalWords)
                        {
                            result.Add(left);
                            string leftWord = s.Substring(left, wordLength);
                            currentWords[leftWord]--;
                            count--;
                            left += wordLength;
                        }
                    }
                    else
                    {
                        currentWords.Clear();
                        count = 0;
                        left = right + wordLength;
                    }

                    right += wordLength;
                }
            }

            return result;
        }
        #endregion

        #region https://leetcode.com/problems/richest-customer-wealth/

        public static int MaximumWealth(int[][] accounts)
        {
            int result = 0;
            var sum = 0;
            foreach (var item in accounts)
            {
                sum = item.Sum();
                if (sum > result)
                    result = sum;
            }
            return result;
        }
        #endregion

        #region https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/

        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var maxVal = candies.Max();
            var result = new List<bool>();
            for (int i = 0; i < candies.Length; i++)
                result.Add(candies[i] + extraCandies >= maxVal ? true : false);
            return result;
        }
        #endregion

        #region https://leetcode.com/problems/decompress-run-length-encoded-list/
        public static int[] DecompressRLElist(int[] nums)
        {
            var result = new List<int>();
            for (int i = 0; i < nums.Length; i += 2)
            {
                int len = nums[i];
                while (len > 0)
                {
                    result.Add(nums[i + 1]);
                    len--;
                }
            }
            return result.ToArray();
        }
        #endregion

        #region https://leetcode.com/problems/create-target-array-in-the-given-order/

        public static int[] CreateTargetArray(int[] nums, int[] index)
        {            
            var result = new List<int>();
            for (int i = 0; i < nums.Length; i++)            
                result.Insert(index[i], nums[i]);
            
            return result.ToArray();
        }
        #endregion

        #region https://leetcode.com/problems/count-number-of-pairs-with-absolute-difference-k/     

        public static int CountKDifference(int[] nums, int k)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = nums.Length-1; j > i; j--)
                {
                    if (Math.Abs(nums[i] - nums[j]) == k)
                        result++;
                }
            }

            return result;
        }
        #endregion

        #region https://leetcode.com/problems/summary-ranges/

        public static IList<string> SummaryRanges(int[] nums)
        {
            if (nums.Length < 1)
                return new List<string>();
            var result = new List<string>();
            int j = 0;
            int current = j;
            for (int i = 1; i < nums.Length; i++)
            {                
                if (nums[j] + 1 == nums[i])
                    j++;
                else
                {
                    AddInList(nums,ref current,ref j,result);
                    j++;
                    current = j;
                }
            }
            AddInList(nums, ref current, ref j, result);
            return result;
        }

        private static void AddInList(int[] nums,ref int current,ref int j, List<string> result)
        {
            if (current != j)
                result.Add($"{nums[current]}->{nums[j]}");
            else
                result.Add(nums[current].ToString());
        }

        #endregion
    }
}
