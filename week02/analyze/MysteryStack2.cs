public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _); // Use float.TryParse to validate the string as a float.
    }


    // Create a stack to hold operands during evaluation.
    public static float Run(string text) {
        var stack = new Stack<float>();
        // Split the input text into tokens (numbers or operators).
        foreach (var item in text.Split(' ')) {
            if (item == "+" || item == "-" || item == "*" || item == "/") {
                // Check if there are at least two operands on the stack.
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!"); // Not enough operands for the operation.

                // Pop the top two operands from the stack.
                var op2 = stack.Pop(); // Second operand.
                var op1 = stack.Pop(); // First operand.

                // Perform the operation and store the result.
                float res;
                if (item == "+") {
                    res = op1 + op2; // Addition.
                }
                else if (item == "-") {
                    res = op1 - op2; // Subtraction.
                }
                else if (item == "*") {
                    res = op1 * op2; // Multiplication.
                }
                else {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!"); // Division by zero is not allowed.

                    res = op1 / op2; // Perform division.
                }


                // Push the result back onto the stack.
                stack.Push(res);
            }
            else if (IsFloat(item)) {
                // If the token is a valid number, parse and push it onto the stack.
                stack.Push(float.Parse(item));
            }
            else if (item == "") {
                // Ignore empty strings (e.g., from excess spaces in input).
            }
            else {
                // If the token is neither a number nor a valid operator, throw an error.
                throw new ApplicationException("Invalid Case 3!");
            }
        }


        // After processing all tokens, there should be exactly one item left on the stack.
        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!"); // The expression is invalid if there's more or fewer than one result.
        // Pop and return the final result.
        return stack.Pop();
    }
}