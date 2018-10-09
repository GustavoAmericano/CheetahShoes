using System;
using System.Collections.Generic;

namespace CheetahShoes.Core.Entities
{
    public class Shoe
    {
        public int Id { get; set; }
        public String Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public List<ShoeSize> Sizes { get; set; }


        





    }
}
