using EntityFramework_RestaurantApi.Models;
using EntityFramework_RestaurantApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        //deletes all dishes from the restaurant
        [HttpDelete]
        public ActionResult DeleteAll([FromRoute] int restaurantId)
        {
            var result = _dishService.RemoveAll(restaurantId);
            return Ok($"{result} deleted dishes from the restaurant (id -> {restaurantId})");
        }

        //deletes dish from the restaurant
        [HttpDelete("{dishId}")]
        public ActionResult Delete([FromRoute] int dishId)
        {
            var resultRestaurantId = _dishService.Remove(dishId);
            return Ok($"deleted dish (id -> {dishId}) from the restaurant ( id -> {resultRestaurantId})");
        }


        //adds dishes to the restaurant
        [HttpPost]
        public ActionResult Post([FromRoute]int restaurantId,[FromBody] CreateDishDto dto)
        {
            var newDishId = _dishService.Create(restaurantId, dto);

            return Created($"api/restaurant/{restaurantId}/dish/{newDishId}", null);
        }


        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            DishDto dish = _dishService.GetById(restaurantId, dishId);
            return Ok(dish);
        }

        [HttpGet]
        public ActionResult<List<DishDto>> Get([FromRoute] int restaurantId)
        {
            var result = _dishService.GetAll(restaurantId);
            return Ok(result);
        }


    }
}
