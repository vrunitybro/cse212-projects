public class CustomerService {
    public static void Run() {
        var cs = new CustomerService(10);
        Console.WriteLine(cs);

        // Test 1: Initialize with invalid size
        // Expected: Queue size should default to 10
        var csInvalid = new CustomerService(0);
        Console.WriteLine(csInvalid);  // [size=0 max_size=10]

        // Test 2: Add customers and reach maximum capacity
        for (int i = 1; i <= 10; i++) {
            cs.AddNewCustomer($"Customer {i}", $"ID-{i}", "Issue");
        }
        // Try to add one more customer and expect an error message
        cs.AddNewCustomer("Extra Customer", "ID-11", "Over capacity");

        // Test 3: Serve customers until empty
        for (int i = 0; i < 10; i++) {
            cs.ServeCustomer();
        }
        // Try to serve from an empty queue and expect an error message
        cs.ServeCustomer();
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

    private class Customer {
        public string Name { get; }
        public string AccountId { get; }
        public string Problem { get; }

        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        public override string ToString() {
            return $"{Name} ({AccountId}) : {Problem}";
        }
    }

    private void AddNewCustomer(string name, string accountId, string problem) {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers to serve.");
            return;
        }

        var customer = _queue[0];
        Console.WriteLine(customer);
        _queue.RemoveAt(0);
    }

    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
