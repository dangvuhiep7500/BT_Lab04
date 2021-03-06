namespace BT_Lab04.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }

        [StringLength(128)]
        public string LecturerId { get; set; }

        [Required(ErrorMessage = "The Place is required")]
        [StringLength(225)]
        public string Place { get; set; }

        public DateTime DateTime { get; set; }
        [Required(ErrorMessage = "Category is required")]

        public int? CategoryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }
        public string Name;
        public string LectureName;
        public List<Category> ListCategory = new List<Category>();

        public bool isLogin = false;
        public bool isShowGoing = false;
        public bool isShowFollow = false;

        public virtual Category Category { get; set; }
    }
}
