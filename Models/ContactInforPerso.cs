using System.ComponentModel.DataAnnotations.Schema;

namespace FormationVueDotnet.Models
{
    public class ContactInfoPerso
    {
        public int Id { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public string Mail { get; set; }
        public string FixedPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public virtual Person Person { get; set; }
    }
}