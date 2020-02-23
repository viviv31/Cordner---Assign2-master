using System;
using System.Collections.Generic;
using System.Linq;

namespace Cordner___Assign2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Question 1");
            //int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            //int target = 9;
            //int[] r = TargetRange(l1, target);
            // Write your code to print range r here

            // Console.WriteLine("Question 2");
            //string s = "University of South Florida";
            //string rs = StringReverse(s);
            //Console.WriteLine(rs);

            //Console.WriteLine("Question 3");
            //int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            //int sum = MinimumSum(l2);
            //Console.WriteLine(sum);

            //Console.WriteLine("Question 4");
            //string s2 = "xacabbzzcyzax";
            //string sortedString = FreqSort(s2);
            //Console.WriteLine(sortedString);

            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            //Console.WriteLine("[{0}]", string.Join(", ", intersect1));
            Console.WriteLine("\n");
            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            //Console.Write("[" + String.Join(",", intersect2.Select(p => p.ToString())) + "]");
            Console.WriteLine("\n");

            //Console.WriteLine("Question 6");
            //char[] arr = new char[] { 'a', 'g', 'h', 'a' };
            //int k=3;
            //Console.WriteLine(ContainsDuplicate(arr, k));

            //Console.WriteLine("Question 7");
            //int rodLength = 25;
            //int priceProduct = GoldRod(rodLength);
            //Console.WriteLine(priceProduct);

            //Console.WriteLine("Question 8");
            //string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            //string keyword = "hhllo";
            //Console.WriteLine(DictSearch(userDict, keyword));

            //Console.WriteLine("Question 8");
            //SolvePuzzle();

        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }
        static int[] TargetRange(int[] l1, int target)
        {
            int[] arr = new int[2] { -1, -1 };

            for (int i = 0; i < l1.Length; i++)
            {
                if (l1[i] == target)
                {
                    if (arr[0] == -1)
                    {
                        arr[0] = i;
                        arr[1] = i;
                    }
                    else
                    {
                        arr[1] = i;
                    }
                }
            }
            return arr;
        }

        public static string StringReverse(string s)
        {
            string rs = "";
            string tmp = "";
            string ltr = "";                // we add this variable to save the value of s


            for (int i = 0; i < s.Length; i++)
            {
                ltr = s[i].ToString();
                // Here the letters of the string s are saved and transformed into a string, with that we can add the other letters inside the rs

                if (ltr == " ")
                {
                    rs += tmp + " ";
                    tmp = "";
                }
                else
                {
                    tmp = ltr + tmp;
                }
            }
            rs += tmp;
            return rs;
        }

        public static int MinimumSum(int[] l2)
        {



            int sum = 0;
            for (int i = 0; i < l2.Length; i++) //Here we wanted to create a loop that will growth till i was less than l2
            {
                if (i + 1 < l2.Length) //the if condition here will help us to determine if we increase the value of our parameter or not
                {
                    if (l2[i] == l2[i + 1])
                    {
                        l2[i + 1]++;// Here we are saying that if the parameters inside the array are equal then we add 1 to the following one
                    }
                }
                sum += l2[i];// Finally, here we just add all the elements from the array

            }
            return sum;
        }

        public static string FreqSort(string s2)
        {
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();
            string outstring = String.Empty;
            Boolean multi = false;

            try
            {
                // put ea char into dictionary with value as frequency
                foreach (char c in s2)
                {
                    if (!dict.ContainsKey(c)) dict.Add(c, 1);
                    else
                    {
                        dict[c] = dict[c] + 1;
                        multi = true;
                    }
                }

                //if no multiple characters just force exception
                if (multi == false) outstring = null;

                //order dict by freq and populate string with most frequent first
                foreach (var item in dict.OrderByDescending(r => r.Value))
                {
                    for (int i = 1; i <= item.Value; i++)
                        outstring = outstring + item.Key;
                }
            }
            catch (NullReferenceException)
            {
                return outstring = "There ain't no double letters in your string";
            }
            catch (Exception)
            {
                throw;
            }

            return outstring;
        }

        public static int[] Intersect1(int[] nums1, int[] nums2)

        {
            int[] inter = new int[] { };
            try
            {
                Array.Sort(nums1);
                Array.Sort(nums2);

                int long1 = nums1.Length;
                int long2 = nums2.Length;

                String intersectionset = "";

                int v = 0;
                int m = 0;

                if (nums2 is null || nums2 is null)
                {
                    inter = new int[] { };
                }
                else
                {
                    while (v < long1 && m < long2)
                    {
                        if (nums1[v] == nums2[m])
                        {
                            intersectionset += nums1[v];
                            v++;
                            m++;
                        }
                        else if (nums1[v] < nums2[m])
                        {
                            v++;
                        }
                        else
                        {
                            m++;
                        }

                    }

                }

                inter = new int[intersectionset.Length];
                for (int a = 0; a < intersectionset.Length; a++)
                {
                    inter[a] = int.Parse(intersectionset[a].ToString());
                }

            }
            catch
            {
                throw;
            }
            return inter;

        }


        public static int[] Intersect2(int[] nums1, int[] nums2)

        {
            var primarydict = nums1.Select((index, value) => new { value, index })
                      .ToDictionary(pair => pair.value, pair => pair.index);

            var secondarydict = nums2.Select((index, value) => new { value, index })
                      .ToDictionary(pair => pair.value, pair => pair.index);

            //outputs index of intersection in terms of nums1
            var resultDict = primarydict.Keys.Intersect(secondarydict.Keys)
                                          .ToDictionary(t => t, t => primarydict[t]);

            int x = resultDict.Count;
            int[] retrn = new int[x];

            for (int i = 0; i < x; i++)
                retrn[i] = resultDict[i];

            return retrn;
        }
        public static bool ContainsDuplicate(char[] arr, int k)
        {
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();
            Boolean foundit = false;

            try
            {//key is char and value is distance to nearest reoccurance
                for (int i = 0; i <= arr.Length-1; i++)
                {
                    if (!dict.ContainsKey(arr[i]))
                        dict.Add(arr[i], 0);
                    
                    else
                    {//change value to distance to previous occurance of key
                        dict[arr[i]] = i - dict[arr[i]];

                        if (dict[arr[i]] <= k)
                        {//if the distance is less than or equal to key value
                            foundit = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return foundit;
        }
        public static int GoldRod(int rodLength)
        {
            int x = 1;
            int y = 1;

            try
            {// breaking rod in sections of 3 is most profitable - never have segment of 1 left over
                if (rodLength == 3) x = rodLength;
                else if (rodLength > 4)         
                {
                    x = 3;
                    y = GoldRod(rodLength - 3);
                }
                else if (rodLength >= 2)
                {
                    x = 2;
                    y = GoldRod(rodLength - 2);
                }
            }

            catch (Exception)
            {
                throw;
            }
            return x * y;
        }
        public static bool DictSearch(string[] userDict, string keyword)
        {
            int x = userDict.Length;
            Boolean foundit = false;

            try
            {   // trigger exception if nothing is entered
                if (keyword == String.Empty) keyword = null;

                for (int i = 0; i < x; i++)
                {
                    // check if keyword and dict word are of same length
                    if (userDict[i].Length == keyword.Length)
                    {//compute if changing 1 char would make strings match
                        int distance =
                            userDict[i].ToCharArray()
                            .Zip(keyword.ToCharArray(), (c1, c2) => new { c1, c2 })
                            .Count(m => m.c1 != m.c2);

                        if (distance == 1)
                        {
                            foundit = true;
                            break;
                        }
                    }
                }

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("You did not enter a value for the keyword...how tacky");
                return foundit; 
            }
            catch (Exception)
            {
                throw;
            }

            Console.Write("Input: " + keyword + "  Output: ");
            return foundit;
        }
        public static void SolvePuzzle()    
        {
            string[] iostr = new string[3];
            string unichar = String.Empty;
            string[] outnumstr = new string[3];

            try
            {
                iostr = GetStrings();                // get user input

                unichar = UniqueCharacaters(iostr);  //gets string of unique characters

                outnumstr = CalculateAnswer(unichar, iostr);

                Console.WriteLine(iostr[0] + ":" + outnumstr[0]);
                Console.WriteLine(iostr[1] + ":" + outnumstr[1]);
                Console.WriteLine(iostr[2] + ":" + outnumstr[2]);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Operation Aborted....Come back after one year!");
                return;
            }
            catch
            {
                throw;
            }
            return;
        }

        public static string[] GetStrings()
        {//get input strings from user and check for errors
            string[] iostr = new string[3];

            Console.WriteLine("Please enter two input strings, and an output string and hit ENTER after each");
            iostr[0] = Console.ReadLine();
            iostr[1] = Console.ReadLine();
            iostr[2] = Console.ReadLine();

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    iostr[i] = iostr[i].ToLower();          //ensure lowercase
                    iostr[i] = iostr[i].Replace(" ", "");   //ensure no spaces

                    if (iostr[i].Any(c => char.IsDigit(c)) == true)
                    {
                        Console.WriteLine("You entered a number instead of a string. FIX IT!");
                        iostr = null;
                    }
                    else if (iostr[i] == String.Empty)
                    {
                        Console.WriteLine("You entered a blank string....that's just dumb.");
                        iostr = null;
                    }
                }

                //check lengths of strings. Since adding, can't have an output string longer than
                // one digit more than the input strings. Also, if input strings are of different lengths
                // the output string can't be longer than longest input string.
                if (iostr[2].Length - iostr[1].Length > 1 & iostr[2].Length - iostr[0].Length > 1)
                {
                    Console.WriteLine("The output string can't be more than 1 char longer than the longest input string");
                    iostr = null;
                }
                else if (iostr[0].Length != iostr[1].Length)
                {
                    if (iostr[2].Length > iostr[0].Length | iostr[2].Length > iostr[1].Length)
                    {
                        Console.WriteLine("The output string can't be longer than input when input strings are of different lengths");
                        iostr = null;
                    }
                }
            }
            catch
            {
                throw;
            }

            return iostr;
        }
        public static string UniqueCharacaters(string[] iostr)
        {//return a string of unique characters from all three input strings
            string tstr = String.Empty;

            tstr = iostr[0] + iostr[1] + iostr[2];
            tstr = String.Join("", tstr.Distinct());

            return tstr;
        }
        public static SortedDictionary<char, int> SetupDict(string unichar, string outstr) 
        {//setup dictionary of unique char as key and their values
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();
            Random rnd = new Random();

            int x = rnd.Next(1, unichar.Length - 1);

            // set all char to 0
            foreach (char value in unichar) dict.Add(value, 0);

            //set one random letter to 1
            dict[unichar[x]] = 1;    

            return dict;
        }
        public static int GetStringNum(string s, SortedDictionary <char, int> dict)
        {//Converts numbers of individual char into string numbers to represent input strings
         // and returns them as numbers.

            int num = 0;
            string numstr = String.Empty;

            foreach (char c in s) numstr = numstr + dict[c];
            num = Convert.ToInt32(numstr);
            return num;
        }
        public static string StringNumResults(string s, SortedDictionary<char,int> dict)
        {// returns numbers representing input strings as strings.
            string numstr = String.Empty;

            foreach(char c in s) numstr = numstr + dict[c];
            return numstr;
        }
        public static List<char> Uncommon(string instr1, string instr2, string outstr)
        {// get characters that only appear once across all strings
            string noncom = String.Empty;
            foreach (char c in instr1)
                if (!instr2.Contains(c) & !outstr.Contains(c)) noncom = noncom + c;
            foreach (char c in outstr)
                if (!instr1.Contains(c) & !instr2.Contains(c)) noncom = noncom + c;
            foreach (char c in instr2)
                if (!instr1.Contains(c) & !outstr.Contains(c)) noncom = noncom + c;

            var xyz = noncom.ToList();

            for (int g = 0; g < xyz.Count - 1; g++)
            {
                if (xyz[g] == xyz[g + 1])
                {
                    xyz.RemoveAt(g);
                    xyz.RemoveAt(g);
                }
            }
            return xyz;
        }
        public static string[] CalculateAnswer(string unichar, string[] iostr)
        {//where all the magic happens....computes answer to 'puzzle'
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();
            List<char> noncom = new List<char>();

            string instr1 = iostr[0];
            string instr2 = iostr[1];
            string outstr = iostr[2];
            string[] outnumstr = new string[3];

            Boolean longer = false;

            int i=0;
            int j=0;
            int w = 0;

            //get dict of char as key and values set to random numbers
            dict = SetupDict(unichar, outstr);

            //get number associated with each string as a number
            int innum1 = GetStringNum(instr1, dict);
            int innum2 = GetStringNum(instr2, dict);
            int outnum = GetStringNum(outstr, dict);

            //if out str is longer than inputs -  first char of output can't be more than 1 if true
            if (outstr.Length > instr1.Length | outstr.Length > instr2.Length) longer = true;

            // get list of char not common across multiple strings
            noncom = Uncommon(instr1, instr2, outstr);

            try
            {//w is just a counter to keep the loop from running too long
                while (innum1 + innum2 != outnum & w < 1000000)
                {
                    int sum = innum1 + innum2;

                    // get position in strings of where difference is occuring
                    i = (outstr.Length-1) - Convert.ToInt32((Convert.ToString(outnum - sum).Length));
                    j = outstr.Length - Convert.ToInt32((Convert.ToString(sum).Length));

                    if (longer == true)
                    {   // adjust input char if sum is lower than output number
                        if (outnum - sum > 0)
                        {  // increase the noncommon char first
                            if (noncom.Contains(instr1[i]))
                            {
                                if (instr1[i] != outstr[0])
                                    if (dict[instr1[i]] < 9) dict[instr1[i]]++;
                            }
                            else if (noncom.Contains(instr2[i]))
                            {
                                if (instr2[i] != outstr[0])
                                    if (dict[instr2[i]] < 9) dict[instr2[i]]++;
                            }

                            //if neither is noncommon update the first string if its within limits
                            else if (instr1[i] != outstr[0] & dict[instr1[i]] < 9)
                                dict[instr1[i]]++;
                            else if (instr2[i] != outstr[0] & dict[instr2[i]] < 9)
                                dict[instr2[i]]++;
                        }
                        else
                        { // adjust output char if output is lower than input sum
                            if (j == 0 & dict[outstr[j]] < 1) dict[outstr[j]]++;
                            else if (j != 0)
                            {
                                if (dict[outstr[j]] < 9) dict[outstr[j]]++;
                            }
                        }
                    }
   
                    // get new numbers after adjustments
                    innum1 = GetStringNum(instr1, dict);
                    innum2 = GetStringNum(instr2, dict);
                    outnum = GetStringNum(outstr, dict);

                    w++;
                } 
            }
            catch
            {
                // no man's land
                throw;
            }

            // set values for return
            outnumstr[0] = StringNumResults(instr1, dict);
            outnumstr[1] = StringNumResults(instr2, dict);
            outnumstr[2] = StringNumResults(outstr, dict);

            return outnumstr;
        }
    }
}
