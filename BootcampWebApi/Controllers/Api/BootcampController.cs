using BootcampWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootcampWebApi.Controllers.Api
{
    [ApiController]
    [Route("api/bootcamp")]
    public class BootcampController : ControllerBase
    {
        public static List<Participant> ParticipantList = new();

        [HttpGet]
        public List<Bootcamp> GetBootcamps()
        {
            var bootcampList = AdminController.BootcampList.OrderBy(x => x.Id).ToList();
            return bootcampList;
        }

        [HttpGet("{id}")]
        public Participant GetById(int id)
        {
            var participant = ParticipantList.Where(participant => participant.Id == id).SingleOrDefault();
            return participant;
        }

        [HttpPost]
        public IActionResult AddParticipant([FromBody] Participant newParticipant)
        {
            var bootcamp = AdminController.BootcampList.SingleOrDefault(x => x.Id == newParticipant.BootcampId);
            if (bootcamp is null)
                return BadRequest("There is no bootcamp with the ID number you selected.");

            var participant = ParticipantList.SingleOrDefault(x => x.BootcampId == newParticipant.BootcampId);
            if (participant is not null)
                return BadRequest("You have applied to this bootcamp before.");

            newParticipant.Status = false;
            ParticipantList.Add(newParticipant);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult ConfirmParticipant(int id, [FromBody] Participant updatedParticipant)
        {
            var participant = ParticipantList.SingleOrDefault(x => x.Id == id);
            if (participant is null)
                return BadRequest();

            participant.Id = updatedParticipant.Id != default ? updatedParticipant.Id : participant.Id;
            participant.TcNumber = updatedParticipant.TcNumber != "string" ? updatedParticipant.TcNumber : participant.TcNumber;
            participant.Name = updatedParticipant.Name != "string" ? updatedParticipant.Name : participant.Name;
            participant.Surname = updatedParticipant.Surname != "string" ? updatedParticipant.Surname : participant.Surname;
            participant.GsmNumber = updatedParticipant.GsmNumber != "string" ? updatedParticipant.GsmNumber : participant.GsmNumber;
            participant.BootcampId = updatedParticipant.BootcampId != default ? updatedParticipant.BootcampId : participant.BootcampId;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var bootcamp = ParticipantList.SingleOrDefault(x => x.Id == id);

            if (bootcamp is null)
                return BadRequest();

            ParticipantList.Remove(bootcamp);
            return Ok();
        }
    }
}
