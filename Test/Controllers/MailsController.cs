using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        DataContext _db;
        public MailsController(DataContext context)
        {
            _db = context;
        }
        // GET api/mails
        [HttpGet]
        public ActionResult<IEnumerable<Mail>> Get()
        {
            return _db.Mails.ToList();
        }
        // POST api/mails
        [HttpPost]
        public async Task<ActionResult<Mail>> Post([FromBody] MailDetails mailDetails)
        {
            _db.Mails.Add(new Mail(mailDetails));
            await _db.SaveChangesAsync();
            return Ok(mailDetails);
        }
    }
}
