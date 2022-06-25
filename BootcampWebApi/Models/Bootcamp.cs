namespace BootcampWebApi.Models
{
    public class Bootcamp
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Quota { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        // 1-Monday 2-Tuesday 3-Wednesday 4-Thursday 5-Friday 6-Saturday 7-Sunday
        public string Day { get; set; } 
    }
}
