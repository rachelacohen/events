using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Calender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IDataContext _dataContext;

        public EventsController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataContext.EventList);
        }

        // GET: api/<EventsController>



        //GET api/<EventsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var x= _dataContext.EventList.Find(x=>x.Id==id);
            if(x==null)
                return NoContent(); 
            return Ok(x);
        }

        // POST api/<EventsController>
        [HttpPost]
        public IActionResult Post([FromBody] Event value)
        {
            //  int count = value.Id;

            _dataContext.EventList.Add(new Event {  Title = value.Title, Start = value.Start});
            return Ok(_dataContext.EventList) ;
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Event value)
        {
            var eventId = _dataContext.EventList.Find(eventId => eventId.Id == id);
            if (eventId == null)
                return BadRequest(_dataContext.EventList);
            eventId.Title=value.Title;
            eventId.Start = value.Start;
            return Ok(_dataContext.EventList) ;
           

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eventId = _dataContext.EventList.Find(eventId => eventId.Id == id);
            if (eventId == null)
                return NotFound();

            _dataContext.EventList.Remove(eventId);
            return Ok(_dataContext.EventList);
        }
    }
}
