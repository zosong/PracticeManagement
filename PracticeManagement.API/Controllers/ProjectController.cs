using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticeManagement.API.Database;
using PracticeManagement.API.EC;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;
namespace PracticeManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController: ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ProjectDTO> Get()
        {
            return new ProjectEC().Search();
        }

        [HttpGet("{id}")]
        public ProjectDTO? GetId(int id)
        {
            return new ProjectEC().Get(id);
        }

        [HttpDelete("Delete/{id}")]
        public ProjectDTO? Delete(int id)
        {
            return new ProjectEC().Delete(id);
        }

        [HttpPost]
        public Project AddOrUpdate(Project project)
        {
            return new ProjectEC().AddOrUpdate(project);
        }

        [HttpPost("Search")]
        public IEnumerable<ProjectDTO> Search([FromBody] QueryMessage query)
        {
            return new ProjectEC().Search(query.Query);
        }

    }
}
