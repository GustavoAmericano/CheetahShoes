namespace CheetahShoes.Core.Entities
{
    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public string Terms { get; set; }
    }
}