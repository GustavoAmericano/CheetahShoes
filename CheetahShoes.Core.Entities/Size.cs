namespace CheetahShoes.Core.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public double SizeNumber { get; set; }
        public int Quantity { get; set; }
    }
}