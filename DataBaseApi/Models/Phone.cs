using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseApi.Models
{
    public class Phone
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        public Phone()
        {
            
        }
        public Phone(int id, string number, int personId)
        {
            Id = id;
            Number = number;
            PersonId = personId;
        }

        public override bool Equals(object obj)
        {
            var phone = obj as Phone;
            return phone != null &&
                   Number == phone.Number;
        }

        public override int GetHashCode()
        {
            return 187193536 + EqualityComparer<string>.Default.GetHashCode(Number);
        }
    }
}
