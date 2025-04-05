using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riid.Data;
using Riid.Models;

namespace Riid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> createCategory(CategoryModel category)
        {
            _db.Category.Add(category);
            await _db.SaveChangesAsync();

            return Ok("Category created successfully!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> getAllCategories()
        {
            var categories = await _db.Category.ToListAsync();

            return Ok(categories);
        }

        [HttpPut]
        [Route("{Id:long}")]
        public async Task<ActionResult> putCategory()
        {
            //Terminar
            return Ok("Ok");
        }
    }
}