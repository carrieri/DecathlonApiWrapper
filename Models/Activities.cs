using System.Collections.Generic;

namespace DecathlonApiWrapper.Models
{
    public enum Difficulty
    {
        Beginner = 0,
        Intermediate = 1,
        Advanced = 2
    }

    public class Activity
    {
        public int SportId { get; set; }
        public List<string> Tags { get; set; }
        public Difficulty? Difficulty { get; set; }
        public int? Distance { get; set; }
        public User User { get; set; }
        public string PhotoReference { get; set; }
    }
}
