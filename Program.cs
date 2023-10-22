﻿/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75};
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();
            
            
            
            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();
            

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4};
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();


            
            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            
            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1,2,3,1,1,3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();
            
            
            
            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();
            
            
            
            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();
            
            
            
            
            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
            
            
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                //creating nested list and for every internal range create a new list and append to the nested list
                IList<IList<int>> output = new List<IList<int>>();// IList<IList<int>>();
                IList<int> input = new List<int>();
                int next = lower;
                for(int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] < next)
                    {
                        continue;
                    }
                    if (nums[i] == next) // checking the number in the array is in the range if not create a list and append to the result list
                    {
                        next++;
                        continue;
                    }
                    else
                    {
                        input.Add(next);
                        input.Add(nums[i] - 1);
                        output.Add(input);
                        input = new List<int>();
                        next = nums[i] + 1;
                    }
                }
                if(next <= upper)
                {
                    input.Add(next);
                    input.Add(upper);
                    output.Add(input);
                }

                return output;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                //creating a stack and pushing the open paranthesis to it and pop when the corresponding paranthesys iteration 
                Stack<Char> st = new Stack<char>();
                //bool flag = false;
                //Console.WriteLine(s);
                foreach (char ch in s)
                {
                    if (ch == '(' || ch == '{' || ch == '[')
                    {
                        //Console.WriteLine(ch);
                        st.Push(ch);
                    }
                    else
                    {
                        char c = st.Peek();
                        //Console.WriteLine(c);
                        //Console.WriteLine(ch);
                        if ((c == '(' && ch == ')') || (c == '{' && ch == '}') || (c == '[' && ch == ']'))
                        {
                            st.Pop();
                        }
                        else
                            return false;
                    }
                }
                //After the iteration if the stack is empty then the string is balanced otherwise its not.
                if(st.Count == 0)
                        return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                int minSale = int.MaxValue, maxProfit = 0;
                foreach(int price in prices)
                {
                    //At each day finding the minimum sale up to the current day and comparing it with the maxprofit
                    //If it is Max profit, we will update the variable
                    minSale = Math.Min(minSale, price);
                    maxProfit = Math.Max(maxProfit, price - minSale);
                }
                return maxProfit;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                int start = 0, end = s.Length -1;
                while(start <= end)
                {
                    char left = s[start];   
                    char right = s[end];
                    //mirror characters are 0, 1, 6, 8, 9 
                    //we are checking the start and end character are mirror or not. If they are mirrored then 
                    //increamenting the start and decrememting the end pointers.
                    //If not return false.
                    if ((left == '0' &&  right == '0') || (left == '1' && right == '1') ||
                        (left == '6' && right == '9') || (left == '8' && right == '8') ||
                        (left == '9' && right == '6'))
                    {
                        start++;
                        end--;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                Dictionary<int, int> numCounts = new Dictionary<int, int>();
                int goodPairsCount = 0;
                foreach (int num in nums)
                {
                    //creating a dictionary for storing the numbers and its frequency in the array.
                    if (numCounts.ContainsKey(num))
                    {
                        numCounts[num]++;
                    }
                    else
                    {
                        numCounts[num] = 1;
                    }
                }
                //for each item in the dictionary, finding the number of combinations (nc2).
                foreach (int count in numCounts.Values)
                {
                    goodPairsCount += count * (count - 1) / 2;
                }

                return goodPairsCount;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                
                //Sort the array in the decreasing order
                Array.Sort(nums, (a,b) => b.CompareTo(a));
                int prev = nums[0];
                //Create a new list for storing the unique elements in the list
                List<int> uniquelist = new List<int>();
                for(int i = 1; i < nums.Length; i++)
                {
                    if (prev == nums[i])
                        continue;
                    else
                    {
                        uniquelist.Add(prev);
                        prev = nums[i];
                        //unique_nums[i] = ;
                    }
                }
                uniquelist.Add(prev);
                //For printing the 3rd max, we will check the length of unique numbers and if the length is less than 3 then the first element is returned.
                if(uniquelist.Count >= 3)
                     return uniquelist[2];
                return uniquelist[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
               List<string> result = new List<string>();
                //For every consecutive ++ or -- we will swap + with - (vice versa).
                for(int i = 0; i < currentState.Length-1; i++)
                {
                    if (currentState[i] == '+' && currentState[i+1] == '+')
                    {
                        char[] nextstates = currentState.ToCharArray();
                        nextstates[i] = '-';
                        nextstates[i + 1] = '-';
                        string statepossible = new string(nextstates);
                        result.Add(statepossible);
                    }
                    else
                    {
                        char[] nextstates = currentState.ToCharArray();
                        nextstates[i] = '+';
                        nextstates[i + 1] = '+';
                        string statepossible = new string(nextstates);
                        result.Add(statepossible);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            // Write your code here and you can modify the return value according to the requirements
            string t = "";
           //Iterating over the string and if the character is vowel we will skip the iteration.
           //else the character is append to the result string.
            foreach (char c in s)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                    continue;
                else
                    t = t + c;
            }
            return t;
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
