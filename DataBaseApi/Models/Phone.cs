using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseApi.Models
{
    public class Phone
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        public Phone(int id, string number, int personId)
        {
            Id = id;
            Number = number;
            PersonId = personId;
        }
    }
}
