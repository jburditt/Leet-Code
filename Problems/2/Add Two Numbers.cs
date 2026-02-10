namespace Leet_Code.Problems._2;

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
    // 93.28% runtime and 98.74% memory
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var head = l1; // keep a pointer to the head
        bool remainder = false;
        while (true)
        {
            if (l1 == null)
                l1 = new ListNode();
            l1.val = (l1?.val ?? 0) + (l2?.val ?? 0);
            if (remainder)
                l1.val += 1;
            if (l1.val >= 10)
            {
                remainder = true;
                l1.val -= 10;
            }
            else
                remainder = false;
            if (l1?.next == null && l2?.next == null && !remainder)
                break;
            if (l1.next == null)
                l1.next = new ListNode();
            l1 = l1?.next;
            l2 = l2?.next;
        }
        return head;
    }
}
