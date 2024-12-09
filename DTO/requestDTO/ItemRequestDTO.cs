using System.ComponentModel.DataAnnotations;

namespace StoreyChallenge.DTO.requestDTO
{
    public class ItemRequestDTO
    {
        [Required(ErrorMessage = "El elemento es obligatorio.")]
        public string Element { get; set; }
        [Required(ErrorMessage = "El valor es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a 1.")]
        public int Value { get; set; }
        [Required(ErrorMessage = "La categoría es obligatorio.")]
        public int CategoryId { get; set; }
    }
}
