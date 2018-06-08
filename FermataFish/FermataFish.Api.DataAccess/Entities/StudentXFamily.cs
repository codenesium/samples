using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("StudentXFamily", Schema="dbo")]
        public partial class StudentXFamily: AbstractEntity
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

                [Column("familyId", TypeName="int")]
                public int FamilyId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("studentId", TypeName="int")]
                public int StudentId { get; private set; }

                [ForeignKey("FamilyId")]
                public virtual Family Family { get; set; }

                [ForeignKey("StudentId")]
                public virtual Student Student { get; set; }
        }
}

/*<Codenesium>
    <Hash>4d911fb7b388093d85fa5912bc3a67f6</Hash>
</Codenesium>*/