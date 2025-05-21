using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riid.Data;
using Riid.DTO;
using Riid.Models;

namespace Riid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> createCategory([FromBody] CategoryDTO categoryDTO)
        {
            var category = new CategoryModel
            {
                Id = categoryDTO.Id,
                Description = categoryDTO.Description,
                Name = categoryDTO.Name,
                Books = new List<BookModel>()
            };

            _db.Category.Add(category);
            await _db.SaveChangesAsync();

            return Ok("Category created successfully!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> getAllCategories()
        {
            var categories = await _db.Category.Select(c => new CategoryDTO{
                Id = c.Id,
                Description = c.Description,
                Name = c.Name
            }).ToListAsync();

            return Ok(categories);
        }

        [HttpPut("{Id:long}")]
        public async Task<ActionResult> putCategory(long id, [FromBody]CategoryDTO categoryBody)
        {
            var category = await _db.Category.FindAsync(id);

            if(category == null) return NotFound("Category not found!");
            
            category.Name = categoryBody.Name;
            category.Description = categoryBody.Description;

            await _db.SaveChangesAsync();
            
            return Ok("Category '"+category.Name+"' edited successfully!");
        }

        [HttpDelete("{Id:long}")]
        public async Task<ActionResult> removeCategory(long id)
        {
            var category = await _db.Category.FindAsync(id);

            if(category == null) return NotFound();

            _db.Category.Remove(category);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}