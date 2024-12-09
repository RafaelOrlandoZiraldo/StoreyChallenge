namespace StoreyChallenge.DTO.responseDTO
{
    public class CategoryWithItemsResponse
    {
      public List<CategoryDTO> Categories { get; set; }
       
    }
    public class CategoryDTO
    {
        public string Category { get; set; }
        public List<ItemDTO> Items { get; set; }
    }

    public class ItemDTO
    {
        public string Element { get; set; }
        public int Value { get; set; }
    }
}
