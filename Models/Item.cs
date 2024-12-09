using StoreyChallenge.Interface;

namespace StoreyChallenge.Models
{
    public class Item:IEntity
    {
        public int Id { get; set; } 
        public string Element { get; set; } 
        public int Value { get; set; } 

       
        public int CategoryId { get; set; }
        public Category? Categories { get; set; }
        public bool IsDeleted { get; set; }
    }
}
