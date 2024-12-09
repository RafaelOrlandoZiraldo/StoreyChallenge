using Microsoft.AspNetCore.Mvc;
using StoreyChallenge.DTO.requestDTO;
using StoreyChallenge.DTO.responseDTO;
using StoreyChallenge.Interface;
using StoreyChallenge.Models;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreyChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaResponse>>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }
        }
        [HttpGet("GetCategoriesWithItems")]
        public async Task<ActionResult<CategoryWithItemsResponse>> GetCategoriesWithItems()
        {
            try
            {
                var categories = await _categoryRepository.GetAllWithItems();
                var categoryWithItemsResponse = new CategoryWithItemsResponse
                {
                    Categories = categories.Select(c => new CategoryDTO
                    {
                        Category = c.Name,
                        Items = c.Items.Select(i => new ItemDTO
                        {
                            Element = i.Element,
                            Value = i.Value
                        }).ToList()
                    }).ToList()
                };

                return Ok(categoryWithItemsResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }
            return Ok();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaResponse>> GetCategory(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound("No existe la categoría");
                }
                return Ok(category);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }
           
        }

        // POST api/<CategoryController>
        [HttpPost ]
        public async Task<ActionResult<string>> CreateCategory([FromBody ]CategoryRequestDTO categoryRequest)
        {
           
            try
            {
                var category = new Category
                {
                    Name = categoryRequest.Name,
                };

               await _categoryRepository.AddAsync(category);


            return Ok("Categoría fue creada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateCategoria(int id, [FromBody] CategoryRequestDTO categoryRequest)
        {
            if (categoryRequest == null)
            {
                return BadRequest("La categoría no puede ser nula.");
            }

            try
            {
               
                var existingCategory = await _categoryRepository.GetByIdAsync(id);
                if (existingCategory == null)
                {
                    return NotFound("No existe la categoría");
                }

              
                existingCategory.Name = categoryRequest.Name;

                await _categoryRepository.UpdateAsync(existingCategory);

                return Ok("Categoría fue actualizada");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }
        }
            // DELETE api/<CategoryController>/5
            [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCategoria(int id)
        {
            try
            {
               
                var category = await _categoryRepository.GetByIdAsync(id);

                if (category == null)
                {
                    return NotFound("No existe la categoría");
                }
               
                await _categoryRepository.DeleteAsync(id);

                
                return Ok("Categoría correctamente eliminada ");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }
        }
    }
}
