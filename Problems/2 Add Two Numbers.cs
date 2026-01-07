[TestClass]
public class _2_Add_Two_Numbers
{
    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) 
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var output = new ListNode();
            var head = output; // keep a pointer to the head
            bool remainder = false;
            while (true)
            {
                var l1Value = l1?.val ?? 0;
                var l2Value = l2?.val ?? 0;
                output.val = l1Value + l2Value;
                if (remainder)
                    output.val += 1;
                if (output.val >= 10)
                {
                    remainder = true;
                    output.val -= 10;
                }
                else
                    remainder = false;
                if (l1?.next == null && l2?.next == null && !remainder)
                    break;
                output.next = new ListNode();
                l1 = l1?.next;
                l2 = l2?.next;
                output = output.next;
            }
            return head;
        }
    }
}
