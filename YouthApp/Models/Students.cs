namespace YouthApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Students
    {
        public Guid StudentsID { get; set; }

        [StringLength(20, MinimumLength = 6)]
        public string UniqueID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        public int ClassesID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3)]
        public string OtherNames { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public DateTime DateRegistered { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual StudentsInfo StudentsInfo { get; set; }

        public virtual Classes Classes { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }

        public virtual ICollection<IndividualBills> IndividualBills { get; set; }
    }
}