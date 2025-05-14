
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue
    // Expected Result: Should return highest priority item first

    // Defect(s) Found: 
    // - Returns last occurrence of highest priority instead of first
    // - Doesn't actually remove items from queue

    // Test Result: 
    // Now passes - correctly returns and removes highest priority item 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 5); // Highest priority
        priorityQueue.Enqueue("Item3", 1);
        priorityQueue.Enqueue("Item4", 5); // Same priority as Item2

        // First dequeue should return first highest priority (Item2)
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        // Second should return next highest (Item4)
        Assert.AreEqual("Item4", priorityQueue.Dequeue());
        // Then Item1
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        // Finally Item3
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority
    // Expected Result: Should return items in FIFO order

    // Defect(s) Found:
    // - Doesn't maintain FIFO order for same priority items

    // Test Result: 
    // Now passes - maintains FIFO order for same priority 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Should throw InvalidOperationException

    // Defect(s) Found:
    // - Throws exception but message didn't match requirements

    // Test Result: 
    // Now passes - throws correct exception with proper message
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        
        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Test with negative priorities
    // Expected Result: Should handle negative priorities correctly
    
    // Defect(s) Found:
    // - Original implementation worked but wasn't explicitly tested

    // Test Result: 
    // Passes - handles negative priorities as expected
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Lowest", -5);
        priorityQueue.Enqueue("Middle", 0);
        priorityQueue.Enqueue("Highest", 1);

        Assert.AreEqual("Highest", priorityQueue.Dequeue());
        Assert.AreEqual("Middle", priorityQueue.Dequeue());
        Assert.AreEqual("Lowest", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with multiple dequeues
    // Expected Result: Should maintain correct order after partial dequeues

    // Defect(s) Found:
    // - Queue state wasn't properly maintained between dequeues

    // Test Result: 
    // Now passes - maintains correct state between operations
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3); // Same priority as B

        // First dequeue should return B (first highest)
        Assert.AreEqual("B", priorityQueue.Dequeue());
        // Second should return D (next highest)
        Assert.AreEqual("D", priorityQueue.Dequeue());
        // Then C
        Assert.AreEqual("C", priorityQueue.Dequeue());
        // Finally A
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }
}