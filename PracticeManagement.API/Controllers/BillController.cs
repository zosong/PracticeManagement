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
    public class BillController : ControllerBase
    {
       private readonly ILogger<BillController> _logger;

        public BillController(ILogger<BillController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BillDTO> Get()
        {
            return new BillEC().Search();
        }

        [HttpGet("{id}")]
        public BillDTO? GetId(int id)
        {
            return new BillEC().Get(id);
        }

        [HttpDelete("Delete/{id}")]
        public BillDTO? Delete(int id)
        {
            return new BillEC().Delete(id);
        }

        [HttpPost]
        public Bill AddOrUpdate(Bill bill)
        {
            return new BillEC().AddOrUpdate(bill);
        }

        [HttpPost("Search")]
        public IEnumerable<BillDTO> Search([FromBody] QueryMessage query)
        {
            return new BillEC().Search(query.Query);
        }

    
    }
}
