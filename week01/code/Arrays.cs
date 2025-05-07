public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // --------------------------------------------------------------------------------------------

        // SOLUTION 
        //---------
        // MY UNDERSTANDING OF THE REQUIREMENTS
        // 1. USER INPUT: A starting number and length (That is number of multiples to generate).
        // 2. EXPECTED OUTPUT: An array of doubles where each element is a multiple of the starting number.

        // MAJOR STEPS IN THE IMPLEMENTATION
        //-----------------------------------
        // 1. Create an array of size length to store the results.
        // 2. Use a loop to calculate each multiple:
        // 3. The first element is number * 1.
        // 4. The second element is number * 2.
        // 5. Continue until number * length.
        // 6. Return the populated array.

        // Step 1: Create an array to hold the needed multiples.
        double[] multiples = new double[length];

        // Step 2: Populate the array with multiples of 'number'.
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1); // Calculate the (i+1)th multiple.
        }

        // Step 3: Return the array of multiples.
        return multiples;

    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // --------------------------------------------------------------------------------------------

        // SOLUTION 
        //---------
        // MY UNDERSTANDING OF THE REQUIREMENTS
        // 1. Rotate the list to the right by amount.
        // 2. Example: {1, 2, 3, 4, 5} rotated by 2 becomes {4, 5, 1, 2, 3}.
        // 3. Modify the original list (no new list creation).

        // MAJOR STEPS IN THE IMPLEMENTATION
        //-----------------------------------
        // 1. Use list slicing to split the list into two parts:
        // 2. Part 1: Elements from (data.Count - amount) to the end.
        // 3. Part 2: Elements from the start to (data.Count - amount - 1).
        // 4. Combine the two parts in reverse order (Part 1 followed by Part 2).
        // 5. Clear the original list and add the combined parts back.

        // Step 1: Calculate the split index (where the rotation happens).
        int splitIndex = data.Count - amount;

        // Step 2: Extract the two parts of the list:
        //   - Part 1: Last 'amount' elements.
        //   - Part 2: Remaining elements.
        List<int> part1 = data.GetRange(splitIndex, amount);
        List<int> part2 = data.GetRange(0, splitIndex);

        // Step 3: Clear the original list and rebuild it in rotated order.
        data.Clear();
        data.AddRange(part1); // start by adding Part 1 first.
        data.AddRange(part2); // Then add Part 2.

    }
}
