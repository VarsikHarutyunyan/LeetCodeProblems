using System;

namespace LeetCodeProblems
{
    class Solution
    {
        public int RomanToInt(string s)
        {
            if (s.Length < 1 || s.Length > 16)
            {
                return 0;
            }

            Dictionary<char, int> romanToInt = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

            int sum = 0;
            int n = s.Length;

            for (int i = 0; i < n; i++)
            {
                int currentValue = romanToInt[s[i]];

                if (i + 1 < n && romanToInt[s[i + 1]] > currentValue)
                {
                    sum -= currentValue;
                }
                else
                {
                    sum += currentValue;
                }
            }

            return sum;
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int uniqueIndex = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[uniqueIndex])
                {
                    uniqueIndex++;
                    nums[uniqueIndex] = nums[i];
                }
            }

            return uniqueIndex + 1;
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (!strs.Any()) return "";
            if (strs.Length < 1 && strs.Length > 200)
            {
                return "";
            }
            if (strs.Length == 1)
            {
                return strs[0];
            }
            string word = "";

            var item = strs[0];
            for (int k = 0; k < item.Length; k++)
            {
                var currentSymbol = item[k];
                for (int j = 1; j <= strs.Length - 1; j++)
                {
                    var secondItem = strs[j];
                    if (secondItem.Length > k)
                    {
                        var secondSymbole = secondItem[k];

                        if (j == strs.Length - 1 && secondSymbole == currentSymbol)
                        {
                            word += currentSymbol;
                            continue;
                        }
                        else if (secondSymbole == currentSymbol)
                        {
                            continue;
                        }
                        else
                        {
                            return word;
                        }
                    }
                }
            }
            return word;
        }

        public static bool IsValid(string s)
        {
            if (s == null || s.Length <= 1 || s.Length > 100000) return false;
            Stack<char> stack = new Stack<char>();
            List<char> stackPop = new List<char>();
            List<char> open = new List<char>() { '(', '{', '[' };
            List<char> close = new List<char>() { ')', '}', ']' };
            foreach (char c in s)
            {
                if (open.Contains(c))
                {
                    stack.Push(c);
                }
                else
                {
                    if (!stack.Any())
                    {
                        return false;
                    }
                    int index = close.IndexOf(c);
                    var cOpen = open[index];
                    for (int i = 0; i < stack.Count; i++)
                    {
                        var item = stack.Pop();
                        if (item == cOpen)
                        {
                            if (stackPop.Any())
                            {
                                foreach (var sp in stackPop)
                                {
                                    stack.Push(sp);
                                }
                                stackPop = new List<char>();
                            }
                        }
                        else
                        {
                            stackPop.Add(item);
                        }
                    }
                }
            }
            if (stack.Count > 0 || stackPop.Count > 0)
            {
                return false;
            }
            return true;
        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1.Count() < 0 || list1.Count() > 50 || list2.Count() < 0 || list2.Count() > 50)
            {
                return new ListNode();
            }
            var list1Item = list1.GetEnumerator();
            var list2Item = list2.GetEnumerator();

            ListNode listNodeOrder = new ListNode();
            ListNode tail = listNodeOrder;
            bool hasNext1 = list1Item.MoveNext();
            bool hasNext2 = list2Item.MoveNext();
            while (hasNext1 || hasNext2)
            {
                if (!hasNext1)
                {
                    tail.next = new ListNode(list2Item.Current);
                    hasNext2 = list2Item.MoveNext();
                }
                else if (!hasNext2)
                {
                    tail.next = new ListNode(list1Item.Current);
                    hasNext1 = list1Item.MoveNext();
                }
                else
                {
                    if (list1Item.Current <= list2Item.Current)
                    {
                        tail.next = new ListNode(list1Item.Current);
                        hasNext1 = list1Item.MoveNext();
                    }
                    else
                    {
                        tail.next = new ListNode(list2Item.Current);
                        hasNext2 = list2Item.MoveNext();
                    }
                }

                tail = tail.next;
            }

            return listNodeOrder.next;
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int k = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[k] = nums[i];
                    k++;
                }
            }

            return k;
        }
    }
}



