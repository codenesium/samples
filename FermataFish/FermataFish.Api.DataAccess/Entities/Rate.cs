using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Rate", Schema="dbo")]
        public partial class Rate : AbstractEntity
        {
                public Rate()
                {
                }

                public void SetProperties(
                        decimal amountPerMinute,
                        int id,
                        int teacherId,
                        int teacherSkillId)
                {
                        this.AmountPerMinute = amountPerMinute;
                        this.Id = id;
                        this.TeacherId = teacherId;
                        this.TeacherSkillId = teacherSkillId;
                }

                [Column("amountPerMinute")]
                public decimal AmountPerMinute { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("teacherId")]
                public int TeacherId { get; private set; }

                [Column("teacherSkillId")]
                public int TeacherSkillId { get; private set; }

                [ForeignKey("TeacherId")]
                public virtual Teacher Teacher { get; set; }

                [ForeignKey("TeacherSkillId")]
                public virtual TeacherSkill TeacherSkill { get; set; }
        }
}

/*<Codenesium>
    <Hash>9f807841fb6b0d46b71612671f072621</Hash>
</Codenesium>*/