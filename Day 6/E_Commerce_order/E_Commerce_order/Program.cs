using System;

namespace ECommerceSystem
{
    public abstract class Order
    {
        public int ProductId { get; set; }
        public string Status { get; set; }
        public double BasePrice => 100.0;
    }

    public class PhysicalOrder : Order { public double Weight { get; set; } }
    public class DigitalOrder : Order { public string DownloadUrl { get; set; } }

    // --- Extension Methods (Add logic safely without modifying Order) ---
    public static class OrderExtensions
    {
        public static double ApplySeasonalDiscount(this Order order, double discount) =>
            order.BasePrice - discount;
    }

    public class OrderProcessor
    {
        private int[] _inventory = { 10, 5, 0, 20 }; // Mock stock database

        public void ProcessOrderRequest(string orderIdInput, object order)
        {
            // 1. Out Variables: Parse ID and declare variable inline
            if (!int.TryParse(orderIdInput, out int orderId)) return;

            // 2. Local Function: Reuse validation logic without exposing it
            void LogStatus(string msg) => Console.WriteLine($"[Order {orderId}]: {msg}");

            // 3. Pattern Matching: Process based on type and status
            switch (order)
            {
                case PhysicalOrder p when p.Weight > 50:
                    LogStatus("Handling heavy shipping.");
                    break;
                case DigitalOrder d:
                    LogStatus($"Generating link: {d.DownloadUrl}");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(order));
            }

            // 4. Tuples & Deconstruction: Get multiple values from pricing engine
            // 5. Discards: Ignore the 'tax' value as it's not needed here
            var (price, _, discount) = GetPricingData(order as Order);
            LogStatus($"Final Price: {price - discount}");

            // 6. Ref Locals & Returns: Modify inventory stock directly in the array
            try
            {
                ref int stock = ref GetStockReference((order as Order).ProductId);
                if (stock > 0)
                {
                    stock--; // Directly modifies the _inventory array
                    LogStatus("Inventory updated successfully.");
                }
            }
            catch (Exception ex) { LogStatus(ex.Message); }
        }

        // Returns multiple values via Tuple
        private (double Price, double Tax, double Discount) GetPricingData(Order order)
        {
            // Expression-bodied local return
            return (order.BasePrice, 15.0, 5.0);
        }

        // Ref Return: Points to the actual memory location in the array
        private ref int GetStockReference(int productId)
        {
            if (productId < 0 || productId >= _inventory.Length)
                throw new Exception("Product not found.");

            return ref _inventory[productId];
        }
    }

    // --- Entry Point ---
    class Program
    {
        static void Main()
        {
            var processor = new OrderProcessor();
            var myOrder = new PhysicalOrder { ProductId = 1, Weight = 60, Status = "Pending" };

            processor.ProcessOrderRequest("1024", myOrder);
        }
    }
}