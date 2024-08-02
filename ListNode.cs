using System.Collections;

namespace LeetCodeProblems
{
    public class ListNode : IEnumerable<int>
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public int Count()
        {
            int count = 0;
            ListNode current = next;
            while (current != null)
            {
                count++;
                current = current?.next;
            }
            return count;
        }

        public IEnumerator<int> GetEnumerator()
        {
            ListNode current = next;
            while (next != null)
            {
                yield return next.val;
                current = current?.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
