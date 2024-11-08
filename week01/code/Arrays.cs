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

        //1- Create an arrya that holds the multiples
        //Array should be of type double and of size 'length' since we want to store 'length' multiples
        double[] multiples=new double[length];

        // 2- Use a loop to populate each element of the array.
        // For each index i in the array, the value at that position should be (i + 1) * number.
        // This gives us multiples of 'number' starting from the first multiple (1 * number).

        for (int i = 0; i < length; i++)
        {
            multiples[i] = (i +1) * number;
             // Calculate the (i + 1)th multiple of 'number' and assign it to the current position in the array.
        }

        // Step 3: Return the populated array of multiples.
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

//1: If the amount is 0 or equal to data.Count, no rotation is needed.
        if (amount == 0 || amount == data.Count) return;

        //  2: Calculate the effective rotation amount by using modulo.
        amount = amount % data.Count;

        //  3: Use GetRange to create two sub-lists:
        // Last 'amount' elements (this will move to the front)
        List<int> lastPart = data.GetRange(data.Count - amount, amount);
        // First part (from start to data.Count - amount elements)
        List<int> firstPart = data.GetRange(0, data.Count - amount);

        //  4: Clear the original list and add the lastPart followed by the firstPart.
        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);

        

    }
}
