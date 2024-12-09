using Microsoft.AspNetCore.Mvc;
using StoreyChallenge.Context;
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
    public class ItemController : ControllerBase
    {
        private readonly IRepository<Item> _itemRepository;

        public ItemController(IRepository<Item>  itemRepository)
        {
            _itemRepository = itemRepository;
        }
        // GET: api/<ItemController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemResponse>>> GetAllCategories()
        {
            try
            {
                var items = await _itemRepository.GetAllAsync();

                var itemResponses = items.Select(item => new ItemResponse
                {
                    Id = item.Id,
                    Element = item.Element,
                    Value = item.Value
                }).ToList();

                return Ok(itemResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }
        }

        // GET api/<ItemController>/5
       
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemResponse>> GetItem(int id)
        {
            try
            {
                var item = await _itemRepository.GetByIdAsync(id);
                ItemResponse response = new ItemResponse()
                {
                    Id = item.Id,
                    Element = item.Element,
                    Value = item.Value
                };
                if (item == null)
                {
                    return NotFound("No existe el item");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }

        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] ItemRequestDTO categoryRequest)
        {

            try
            {
                var item = new Item
                {
                    Element=categoryRequest.Element,
                    Value =categoryRequest.Value,
                    CategoryId=categoryRequest.CategoryId
                };

                await _itemRepository.AddAsync(item);


                return Ok("Item fue creado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }

        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] ItemRequestDTO categoryRequest)
        {
            if (categoryRequest == null)
            {
                return BadRequest("La item no puede ser nula.");
            }

            try
            {

                var existingItem= await _itemRepository.GetByIdAsync(id);
                if (existingItem == null)
                {
                    return NotFound("No existe el item");
                }


                existingItem.Element = categoryRequest.Element;
                existingItem.Value = categoryRequest.Value;
                existingItem.CategoryId = categoryRequest.CategoryId;

                await _itemRepository.UpdateAsync(existingItem);

                return Ok("Item fue actualizado");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id) 
        {
            try
            {

                var item = await _itemRepository.GetByIdAsync(id);

                if (item == null)
                {
                    return NotFound("No existe el item");
                }

                await _itemRepository.DeleteAsync(id);


                return Ok("item correctamente eliminado ");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al procesar la solicitud", details = ex.Message });
            }
        }
    }
}
