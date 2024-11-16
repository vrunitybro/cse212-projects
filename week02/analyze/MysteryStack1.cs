public static class MysteryStack1 {
    public static string Run(string text) {
         // Create a stack to store characters from the input string
        var stack = new Stack<char>();

        // Push each character of the input string onto the stack
        foreach (var letter in text)
            stack.Push(letter);// LIFO (Last In, First Out) behavior: last character in will be the first out 
        // Initialize an empty string to build the reversed result
        var result = "";
        // Continue until the stack is empty
        while (stack.Count > 0)
            // Pop removes and returns the top element of the stack
            result += stack.Pop();

        // Return the reversed string
        return result;
    }

    // Input: "racecar" → Output: "racecar"
    // Input: "stressed" → Output: "desserts"
    // Input: "a nut for a jar of tuna" → Output: "anut fo raj a rof tun a"
}