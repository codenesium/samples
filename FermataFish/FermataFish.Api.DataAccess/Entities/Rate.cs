using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Rate", Schema="dbo")]
        public partial class Rate:AbstractEntity
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

                [Column("amountPerMinute", TypeName="money")]
                public decimal AmountPerMinute { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("teacherId", TypeName="int")]
                public int TeacherId { get; private set; }

                [Column("teacherSkillId", TypeName="int")]
                public int TeacherSkillId { get; private set; }

                [ForeignKey("TeacherId")]
                public virtual Teacher Teacher { get; set; }

                [ForeignKey("TeacherSkillId")]
                public virtual TeacherSkill TeacherSkill { get; set; }
        }
}

/*<Codenesium>
    <Hash>b2375fb0106c95021d2cc1282926a89f</Hash>
</Codenesium>*/