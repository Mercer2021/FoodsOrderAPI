using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lib;
using Lib.Entities;
using Microsoft.Extensions.Logging;
using Lib.Data;

namespace FoodsOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly ILogger<FoodItemsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public FoodItemsController(ILogger<FoodItemsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: api/FoodItems
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var foodItems = await _unitOfWork.FoodItems.GetAll();
            return Ok(foodItems);
        }

        // GET: api/FoodItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var foodItem = await _unitOfWork.FoodItems.GetById(id);

            if (foodItem == null)
            {
                return NotFound();
            }

            return Ok(foodItem);
        }

        // PUT: api/FoodItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, FoodItem foodItem)
        {
            if (id != foodItem.Id)
            {
                return BadRequest();
            }
            _unitOfWork.FoodItems.Update(foodItem);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction("GetAll", new { id = foodItem.Id }, foodItem);
        }

        // POST: api/FoodItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> Add(FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.FoodItems.Add(foodItem);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetAll", new { id = foodItem.Id }, foodItem);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        // DELETE: api/FoodItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var girlFriend = await _unitOfWork.FoodItems.GetById(id);
            if (girlFriend == null)
            {
                return BadRequest();
            }
            _unitOfWork.FoodItems.Delete(girlFriend);
            await _unitOfWork.CompleteAsync();
            return Ok(id);
        }
    }
}
