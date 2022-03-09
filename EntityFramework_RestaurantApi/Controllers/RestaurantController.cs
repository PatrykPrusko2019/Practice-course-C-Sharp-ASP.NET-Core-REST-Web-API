using EntityFramework_RestaurantApi.Models;
using EntityFramework_RestaurantApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EntityFramework_RestaurantApi.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize] 
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);

            return NoContent(); // 204 status code
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateRestautant([FromBody] CreateRestaurantDto dto)
        {
            var id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }


        //gets all restaurants
        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDtos = _restaurantService.GetAll();

            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")] // api/restaurant/2
        [AllowAnonymous] // possible access without authorization
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);

            return Ok(restaurant);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRestaurantDto updateRestaurant, [FromRoute] int id)
        {
            _restaurantService.Update(id, updateRestaurant);

            return Ok();
        }
    }
}
