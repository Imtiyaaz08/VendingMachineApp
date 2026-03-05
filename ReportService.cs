public class InventoryChangeLog
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public string ChangeType { get; set; } // e.g., "Added", "Updated", "Removed"
    public DateTime Timestamp { get; set; }
}