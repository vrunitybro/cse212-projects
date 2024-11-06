public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {

        //Arrray to store the final result
        var result = new int[select.Length];

        //Start both counters at 0
        var l1Idx = 0;
        var l2Idx =0;

        //Go through each number in the select array
        for(var i =0; i< select.Length; i++)
        {
            //if it is a 1 from list 1
            if (select[i] ==1)
            {
                result[i] =list1[l1Idx];
                l1Idx++; // move to the bext number in the list1
            }
            else //if it is a 2 from list 2
            {
                result[i]=list2[l2Idx];
                l2Idx++; //move tot he next number in list2
            }
        }

        return result;
    }
}