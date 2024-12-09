using StoreyChallenge.Interface;

namespace StoreyChallenge.Models
{
    public class Category: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
        public bool IsDeleted { get; set; }


    }
}
