using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data.Interface;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IAppDbContext _appDbContext;
        public HomeController(IAppDbContext context)
        {
            _appDbContext = context;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Get()
            => Ok(_appDbContext.TodoSet.ToList());


        [HttpGet]
        [Route("/{id:int}")]
        public IActionResult GetById(int id)
        {
            var model = _appDbContext.TodoSet.FirstOrDefault(x => x.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody] TodoModel todo)
        {
            _appDbContext.TodoSet.Add(todo);
            _appDbContext.SaveChanges();

            return Created($"/{todo.Id}", todo);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo)
        {
            var todoModel = _appDbContext.TodoSet.SingleOrDefault(x => x.Id == id);
            if (todoModel == null) return NotFound();

            todoModel.Title = todo.Title;
            todoModel.Done = todo.Done;

            _appDbContext.TodoSet.Update(todoModel);
            _appDbContext.SaveChanges();

            return Ok(todoModel);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var todoModel = _appDbContext.TodoSet.SingleOrDefault(x => x.Id == id);
            if (todoModel == null) return NotFound();

            _appDbContext.TodoSet.Remove(todoModel);
            _appDbContext.SaveChanges();

            return Ok($"Seu Todo ({todoModel.Title}) foi removido com sucesso");
        }
    }
}
