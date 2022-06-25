namespace BootcampWebApi.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string TcNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GsmNumber { get; set; }
        public int BootcampId { get; set; }
        public bool Status { get; set; }
    }
}
