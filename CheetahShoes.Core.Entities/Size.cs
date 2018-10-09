using System.Collections.Generic;

namespace CheetahShoes.Core.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public double SizeNumber { get; set; }
        public List<ShoeSize> Shoes { get; set; }
    }
}