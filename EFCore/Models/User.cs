// using System;
// using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sporty.Models
{
    public class User
    {
        public int ID { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        // Group Associations
        // public ICollection<Group> Groups { get; set; }
    }
}
