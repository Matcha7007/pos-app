namespace PosAPI.Dtos
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Unit { get; set; }
        public int UnitPrice { get; set; }
    }
}