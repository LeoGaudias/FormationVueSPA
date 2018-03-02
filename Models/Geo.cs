using System.ComponentModel.DataAnnotations.Schema;

namespace FormationVueDotnet.Models
{
    public class Geo
    {
        public int Id { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual Person Person { get; set; }
    }
}