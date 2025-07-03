using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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

        // Steps: -create an empty array to store the results
        //        -set up a loop to itterate multiples of the number up to 
        //            the given length (int i = 1; i <= length; i++)
        //        -multiply the number by i and add it to the array at the appropriate index (i - 1)

        // create an empty array to hold the results
        var results = new double[length];

        // set up a loop to itterate multiples of the number up to the given length
        for (int i = 1; i <= length; i++)
        {
            // multiply the number by i and add it to the array at the appropriate index (i - 1)
            results[i - 1] = number * i;
        }

        return results;
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

        // Steps: -create a new empty list to process the results
        //        -remove 'amount' of items from the end of the list and put into a new array
        //        -add the rest of the original list to the end of the new array
        //        -return the new array

        // create a new empty list to process the results
        var results = new List<int>();

        // move 'amount' of items from the end of the list and put into a new array
        results.AddRange(data.GetRange(data.Count - amount, amount));

        // add the rest of the original list to the end of the new array
        results.AddRange(data.GetRange(0, data.Count - amount));

        // return the new array
        data.Clear();
        data.AddRange(results);
    }
}
