/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections.Generic;
using System.Linq;///for List
using System.Collections;//for Stack
using System.Text;

namespace ISM6225_Assignment_2_Spring_2022
{

    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.Write("Most frequent word is : ");
            Console.WriteLine(commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 3, 3, 4, 4, 4, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.Write("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "bbbcccdddaaa";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int no1 = 0;

                int no2 = nums.Length - 1;

                int con = -1;

                while (no1 <= no2)

                {                                   // binary search logic 
                    int z = (no1 + no2) / 2;       // declaring int z 
                   
                    if (nums[z] == target) // nums is equivalent to target 
                        return z;                 // if target found return z 
                   
                    if (nums[z] > target)  // nums is greater than target 
                   
                    {    //if target is samller than z 
                        no2 = z - 1; 
                        con = z;
                    }

                    else

                    {
                        no1 = z + 1;
                        con = z + 1;
                    }
                }

                return con;
            }

            catch (Exception)

            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned.
        It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the 
        most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), 
        and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */
        public static string smallchar(string sl) // changes to lower case 
        {
            return sl.ToLower();
        }
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            { 
            paragraph = paragraph.ToLower(); // converting the paragraph from uppercase characters to lowercase characters 
            paragraph = paragraph.Replace(',', ' '); // for replacing the string with another string 
            paragraph = paragraph.Replace('.', ' '); 
            paragraph = paragraph.Trim(); // to remove the white spaced characters 

            Console.WriteLine("Output of the Q2"); 

            string[] split = paragraph.Split(' ');

            Dictionary<string, int> map = new Dictionary<string, int>(); //  map - key value pair (string and int)
            for (int l = 0; l < split.Length; l++) // using for loop and incrementing the value 
            {
                if (map.ContainsKey(split[l])) // to check key is mapped into map or not
                {
                    map[split[l]]++;
                }
                else
                {
                    map.Add(split[l], 1);
                }
                for (int e = 0; e < banned.Length; e++) // for loop and incrementing the e 
                {
                    if (split[l] == banned[e])
                    {
                        map.Remove(split[l]);
                    }
                }
            }
            int i = 0;

            string t = "";

            foreach (KeyValuePair <string, int> ans in map) //using foreach loop in map dic
            {
                if (i < ans.Value)
                {
                    i = ans.Value;
                    t = ans.Key;
                }
            }
            return t;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                Dictionary <int, int> li
                    = new Dictionary<int, int>();//created a dictionary
              
                foreach (var digit in arr) // foreach loop to iterate for value and frequency
                {                            
                    if (li.ContainsKey(digit)) // if condition
                    {
                        li[digit] = li[digit] + 1; 
                    }

                    else
                    {
                        li[digit] = 1;
                    }
                }

                var val = li.Keys.ToList();
                int output = -1;                      // returns -1
                foreach (var key in val)
                {                                  //condition for output
                    if (li[key] == key) 
                    {
                        output = (Math.Max(output, key)); // the output which returns the larger of the two specified numbers
                    }
                }
                return output;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your frie
        nd to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
        
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int g = 0;
                int h = 0;
                bool[] val = new bool[secret.Length];
                Dictionary<char, int> map = new Dictionary<char, int>(); // creating the map on char and int 
                for (int j = 0; j < secret.Length; j++) // in for loop iterating the string secret
                {                   
                    if (secret[j] == guess[j]) // if string secret is equivalent to guess then increments 
                    {                           
                        g++;

                        val[j] = true;
                        
                    }
                    else
                    {
                        val[j] = false;     
                        
                        if (map.ContainsKey(secret[j]))
                        {                    
                            map[secret[j]] = map[secret[j]] + 1; // creating the map and assigned the secret string
                        }
                        else
                        {
                            map[secret[j]] = 1;                           
                        }
                    }
                }
                
                for (int m = 0; m < guess.Length; m++) // iterating the guess string
                {                  

                    if (val[m]) continue;    
                    
                    if (map.ContainsKey(guess[m]) && map[guess[m]] > 0)

                    {
                        h++;

                        map[guess[m]] = map[guess[m]] - 1;
                    }
                }
                string op = g + "A" + h + "B";             // string output               
                return op;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int len = s.Length; // int len returns the length of s
                List<int> op = new List<int>(); // creating the list op
                int[] map = new int[26]; 
                for (int m = len - 1; m >= 0; m--) // for loop and decrementing the m
                {
                    if (map[s[m] - 97] == 0)
                    {
                        map[s[m] - 97] = m;
                    }
                }
                int ix = 0;

                while (ix < len) // while loop ix is less than len 
                {
                    int val = ix;

                    int l = map[s[ix] - 97];

                    int diff = l - val + 1;

                    for (int n = val; n <= l; n++) // for loop and incrementing the n
                    {
                        if (map[s[n] - 97] > l)

                        {
                            l = map[s[n] - 97];

                            diff = l - val + 1;
                        }
                    }

                    op.Add(diff); // adding to the op

                    ix = l + 1;
                }


                return op;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, 
        widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters 
        on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you 
        can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int i = 1;
                int pxl = 0;
                for (int m = 0; m < s.Length; m++) // for looping in char
                {                                    
                    int a = s[i] - 97;   //to Substract and get index for the same width
                    
                    if (pxl + widths[a] <= 100) // if case about overflow
                    {            
                        pxl = pxl + widths[a];   // adding line pixel
                    }
                    else
                    {
                        pxl = 0;                         // adding pxl to 0
                        pxl = pxl + widths[a];    // add width to it
                        i++;                                 //increment the value
                    }
                }
                List<int> value = new List<int>();                //creating value list 
                value.Add(i);
                value.Add(pxl);
                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {

            try
            {
                Stack<char> brackets = new Stack<char>();

                for (int m = 0; m < bulls_string10.Length; m++) // for loop iterating the characters 
                {                                        
                    if (bulls_string10[m] == '(' || bulls_string10[m] == '{' || bulls_string10[m] == '[')
                    {    
                        brackets.Push(bulls_string10[m]); // push stack
                    }
                    if (bulls_string10[m] == ')' || bulls_string10[m] == '}' || bulls_string10[m] == ']')   //during close check stack and pop for same 
                    {     
                        if (brackets.Count <= 0) // if condition less than equal to zero will returns the false 
                        {
                            return false;
                        }
                        if (bulls_string10[m] == ')') // for ) bracket 
                        {
                            if (brackets.Peek() == '(') // peek stack
                            {
                                brackets.Pop(); // pop stack
                            }
                            else
                            {
                                return false; 
                            }
                        }
                        if (bulls_string10[m] == '}') // for } bracket
                        {
                            if (brackets.Peek() == '{')
                            {
                                brackets.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        if (bulls_string10[m] == ']') // for ] bracket 
                        {
                            if (brackets.Peek() == '[') 
                            {
                                brackets.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }

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
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation 
            the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words) // words string
        {
            try
            {
                //convert each letter to 0-index, e.g. a-'a', b-'b'

                //declare a translated words array
                //build StringBuilder and save to translated array
                //count unique translation

                //declare a morse code string array - 26
                string[] morse = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

                HashSet<string> set = new HashSet<string>(); //initialising the set  

                
                for (int m = 0; m < words.Length; m++) // for loop and incrementing the m 
                {
                    var le = new StringBuilder(); 
                    foreach (var ab in words[m]) // foreach loop on variable ab in words 
                    {
                        le.Append(morse[ab - 'a']); 
                    }
                    set.Add(le.ToString()); // adding to the string words
                }
                return set.Count(); // return the count for set
            }
            catch (Exception)
            {
                throw;
            }

        }



        /*
            
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally 
        adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time.
        Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */
        public static int findpath(int[,] grid, int m, int n, bool[,] path)
        {

            int columns = grid.GetLength(0); // declaring the columns

            int rows = grid.Length / grid.GetLength(0); // declaring the rows 

            if (m >= rows || n >= columns || m < 0 || n < 0) return 0; // if condition in OR 

            int l1, l2, l3, l4;

            if (path[m, n])
            {
                path[m, n] = false;

                l1 = Math.Max(grid[m, n], findpath(grid, m, n + 1, path));   //right path

                l2 = Math.Max(grid[m, n], findpath(grid, m + 1, n, path));   //down path

                l3 = Math.Max(grid[m, n], findpath(grid, m - 1, n, path));   //top path

                l4 = Math.Max(grid[m, n], findpath(grid, m, n - 1, path));   //left path
            }
            else
            {
                return 0;
            }

            return Math.Max(Math.Max(l1, l2), Math.Max(l3, l4)); //returns the larger of the two specified numbers

        }
        public static int SwimInWater(int[,] grid)
        {
            try
            {
                
               bool[,] way = { { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true } };
                return findpath(grid, 0, 0, way); 
            }
            catch (Exception)
            {   

                throw;
            }
        }
        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */
        public static int abc(string word1, string word2, Dictionary<string, int> word) 
        {
            if (word1 == word2) return 0; // if both are equivalent then 0

                 if (word1 == "") return word2.Length; // it returns the w2 length

            if (word2 == "") return word1.Length; // it returns the w1 length

            string key = word1 + "#" + word2; // key string 

            if (word.ContainsKey(key)) return word[key];

            string string1 = (word1.Length > 1) ? word1.Substring(1) : "";
            string string2 = (word2.Length > 1) ? word2.Substring(1) : "";

            if (word1[0] == word2[0]) // both words are equivalent 

            {
                int st = abc(string1, string2, word);

                word.Add(key, st); 
            }
            else
            {
                int insert_method = 1 + abc(word2[0] + word1, word2, word); // assigning to int insert method 

                int delete_method = 1 + abc(string1, word2, word); // assigning to int delete method

                int replacing = 1 + abc(string1, string2, word); // assigning to replacing method

                int oppp = Math.Min(insert_method, Math.Min(delete_method, replacing)); 

                word.Add(key, oppp);
            }
            return word[key];
        }
        public static int MinDistance(string word1, string word2)
        {
            try
            {
                return abc(word1, word2, new Dictionary <string, int> ()); // return the abc 

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

