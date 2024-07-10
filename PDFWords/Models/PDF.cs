using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Web.Models
{
    public class PDF
    {

        [Key]
        public Guid Guid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }

        public int Words { get; set; }
        public int Characters { get; set; }
        public int DuplicateWords { get; set; }
    }
}
