using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class FoodMenu : ControllerBase
    {
        List<FoodMenuModel> Menu = new List<FoodMenuModel>()
        {
            new FoodMenuModel() { Id = 1, ItemName = "Samabar", Price = 15},
            new FoodMenuModel() { Id = 2, ItemName = "Chutney", Price = 10},

        };

        [HttpGet]
        [Route("")]
        public ActionResult<List<FoodMenuModel>> GetAllMenu()
        {
            return Ok(Menu);
        }

        [HttpGet("{id}")]
        //[Route("{id}", Name = nameof(GetSpecificMenu))]
        public ActionResult<FoodMenuModel> GetSpecificMenu(int id,string test)
        {
            if (id == 0)
                return BadRequest("Please enter a Id in order to view that Menu");

            //return Ok(Menu.Find(option => option.Id==id));
            return Ok($"The Id which you have passed is {id}, and the String which you have passed is {test}");
        }

        [HttpPost]
        public ActionResult<List<FoodMenuModel>> AddNewMenu(FoodMenuModel NewMenu)
        {
            Menu.Add(new FoodMenuModel() { Id = NewMenu.Id, ItemName = NewMenu.ItemName, Price = NewMenu.Price });
            return Ok(Menu);
        }

    }
}
