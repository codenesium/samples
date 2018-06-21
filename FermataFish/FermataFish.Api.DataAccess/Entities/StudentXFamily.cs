using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("StudentXFamily", Schema="dbo")]
        public partial class StudentXFamily : AbstractEntity
        {
                public StudentXFamily()
                {
                }

                public void SetProperties(
                        int familyId,
                        int id,
                        int studentId)
                {
                        this.FamilyId = familyId;
                        this.Id = id;
                        this.StudentId = studentId;
                }

                [Column("familyId")]
                public int FamilyId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("studentId")]
                public int StudentId { get; private set; }

                [ForeignKey("FamilyId")]
                public virtual Family Family { get; set; }

                [ForeignKey("StudentId")]
                public virtual Student Student { get; set; }
        }
}

/*<Codenesium>
    <Hash>2363878a4a11a939811fdf3c05ccef1b</Hash>
</Codenesium>*/