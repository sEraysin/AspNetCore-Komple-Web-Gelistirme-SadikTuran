using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public class MeetingInfo
    {
        public int Id { get; set; }
        public string? Location { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
    }
}