using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Added 4 items to queue with different priorities and dequeued them
    // Expected Result: D, C, B, A
    // Defect(s) Found: D is being returned when C should be instead. Dequeue method
    // is not removing items from the queue (fixed).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        var A = new PriorityItem("A", 1);
        var B = new PriorityItem("B", 2);
        var C = new PriorityItem("C", 3);
        var D = new PriorityItem("D", 4);

        priorityQueue.Enqueue(A.Value, A.Priority);
        priorityQueue.Enqueue(D.Value, D.Priority);
        priorityQueue.Enqueue(B.Value, B.Priority);
        priorityQueue.Enqueue(C.Value, C.Priority);

        PriorityItem[] expected = { D, C, B, A };

        for (int i = 0; i < 4; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expected[i].Value, item);
        }
    }

    [TestMethod]
    // Scenario: Added 4 items to queue, two with the same priority, and dequeued them
    // Expected Result: D, B, C, A
    // Defect(s) Found: Queue moved the priority index to subsequent items with the same priority
    // adjusted code to only look for higher priority, not equal priority
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        var A = new PriorityItem("A", 1);
        var B = new PriorityItem("B", 2);
        var C = new PriorityItem("C", 2);
        var D = new PriorityItem("D", 4);

        priorityQueue.Enqueue(A.Value, A.Priority);
        priorityQueue.Enqueue(D.Value, D.Priority);
        priorityQueue.Enqueue(B.Value, B.Priority);
        priorityQueue.Enqueue(C.Value, C.Priority);

        PriorityItem[] expected = { D, B, C, A };

        for (int i = 0; i < 4; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expected[i].Value, item);
        }
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Added no items to queue. then attempted to dequeue an item
    // Expected Result: "The Queue is empty"
    // Defect(s) Found: No issues found. Correct exception is being thrown
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception ex)
        {
            Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", ex.GetType(), ex.Message));
        }
    }
}