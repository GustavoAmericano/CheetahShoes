namespace CheetahShoes.Core.Entities
{
    public class ShoeSize
    {
        public Shoe Shoe { get; set; }
        public int ShoeId { get; set; }
        public Size Size { get; set; }
        public int SizeId { get; set; }
        public int Stock { get; set; }
    }
}