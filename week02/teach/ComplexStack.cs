public static class ComplexStack {
    public static void Main(){
        Console.WriteLine(CheckBraces("(a == 3 or (b == 5 and c == 6))"));
// (: Push stack → Stack: (.
// Characters a == 3 or are ignored (they are not brackets).
// (: Push stack → Stack: ( (.
// Characters b == 5 and c == 6 are ignored.
// ): Pop and check → Stack top was (, which matches ). Stack: (.
// ): Pop and check → Stack top was (, which matches ). Stack: empty.
// Final Stack Check: Stack is empty, meaning all brackets were balanced.
// Expected Output: True
        Console.WriteLine(CheckBraces("(students]i].Grade > 80 and students[i].Grade < 90"));
// stack: Empty
// (: Push stack → Stack: (.
// Characters students are ignored.
// ]: Pop and check → Stack top was ( does not match ].
// Failure: At this point, the code returns false because the top of the stack didn’t match the expected opening bracket for ].
// Contents of the Stack when Failure Occurs: (.
// Expected Output: False

        Console.WriteLine(CheckBraces("(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))"));
// Initial stack: Empty
// Output: False (Missing final ), stack contents: ()





    }









    public static bool DoSomethingComplicated(string line) {
        var stack = new Stack<char>();
        foreach (var item in line) {
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}