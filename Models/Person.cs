using System;
using System.Collections.Generic;

namespace FormationVueDotnet.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string Twitter { get; set; }
        public string Slack { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
        public string Url { get; set; }
        public virtual ContactInfoPro ContactInfoPro { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }
        public string Entity { get; set; }
        public string CurrentClient { get; set; }
        public string Workcity { get; set; }
        public string WorkAdress { get; set; }
        public string Manager { get; set; }
        public string Department { get; set; }
        public List<Skill> Skills { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string SocialNumber { get; set; }
        public virtual ContactInfoPerso ContactInfoPerso { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public string DriverLicence { get; set; }
        public string TshirtSize { get; set; }
        public int NumberOfChild { get; set; }
        public virtual Geo Geo { get; set; }
    }
}