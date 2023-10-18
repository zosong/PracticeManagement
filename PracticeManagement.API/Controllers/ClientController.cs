using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticeManagement.API.Database;
using PracticeManagement.API.EC;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;
using System.Diagnostics;
using System.Linq;

namespace PracticeManagement.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ClientDTO> Get()
        {
            return new ClientEC().Search();
        }


        [HttpGet("{id}")]
        public ClientDTO? GetId(int id)
        {
            return new ClientEC().Get(id);
        }


        [HttpDelete("Delete/{id}")]
        public ClientDTO? Delete(int id)
        {
            return new ClientEC().Delete(id);
        }

        [HttpPost]
        public Client AddOrUpdate([FromBody] Client client)
        {
            return new ClientEC().AddOrUpdate(client);
        }


        [HttpPost("Search")]
        public IEnumerable<ClientDTO> Search([FromBody] QueryMessage query)
        {
            return new ClientEC().Search(query.Query);
        }

    }
}
