using Microsoft.AspNetCore.Mvc;
using BootcampWebApi.Models;

namespace BootcampWebApi.Controllers.Api
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        public static List<Bootcamp> BootcampList = new();

        [HttpGet]
        public List<Participant> GetParticipants()
        {
            var participantList = BootcampController.ParticipantList.OrderBy(x => x.Id).ToList();
            return participantList;
        }

        [HttpGet("{id}")]
        public Bootcamp GetById(int id)
        {
            var bootcamp = BootcampList.Where(bootcamp => bootcamp.Id == id).SingleOrDefault();
            return bootcamp;
        }

        [HttpPost]
        public IActionResult AddBootcamp([FromBody] Bootcamp newBootcamp)
        {
            var bootcamp = BootcampList.SingleOrDefault(x => x.Title == newBootcamp.Title);

            if (bootcamp is not null)
                return BadRequest();

            BootcampList.Add(newBootcamp);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult ConfirmParticipant(int id, [FromBody] bool status)
        {
            var participant = BootcampController.ParticipantList.SingleOrDefault(x => x.Id == id);
            if (participant is null)
                return BadRequest();

            participant.Status = status;
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult ConfirmParticipant(int id, [FromBody] Bootcamp updatedBootcamp)
        {
            var bootcamp = BootcampList.SingleOrDefault(x => x.Id == id);
            if (bootcamp is null)
                return BadRequest();

            bootcamp.Id = updatedBootcamp.Id != default ? updatedBootcamp.Id : bootcamp.Id;
            bootcamp.Title = updatedBootcamp.Title != "string" ? updatedBootcamp.Title : bootcamp.Title;
            bootcamp.Quota = updatedBootcamp.Quota != default ? updatedBootcamp.Quota : bootcamp.Quota;
            bootcamp.Deadline = updatedBootcamp.Deadline != default ? updatedBootcamp.Deadline : bootcamp.Deadline;
            bootcamp.Start = updatedBootcamp.Start != default ? updatedBootcamp.Start : bootcamp.Start;
            bootcamp.End = updatedBootcamp.End != default ? updatedBootcamp.End : bootcamp.End;
            bootcamp.Day = updatedBootcamp.Day != "string" ? updatedBootcamp.Day : bootcamp.Day;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var bootcamp = BootcampList.SingleOrDefault(x => x.Id == id);

            if (bootcamp is null)
                return BadRequest();

            BootcampList.Remove(bootcamp);
            return Ok();
        }
    }
}
