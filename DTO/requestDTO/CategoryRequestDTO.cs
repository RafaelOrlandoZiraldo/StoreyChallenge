using System.ComponentModel.DataAnnotations;

namespace StoreyChallenge.DTO.requestDTO
{
    public class CategoryRequestDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }

    }
}
