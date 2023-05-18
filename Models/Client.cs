using System;
namespace Full_Stack_Mercury_Maps.Models
{
    public class Client
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public bool HasBC { get; set; }
        public bool NewClient { get; set; }
        public DateTime Birthday { get; set; }

        //public User User { get; set; }
    }
};
