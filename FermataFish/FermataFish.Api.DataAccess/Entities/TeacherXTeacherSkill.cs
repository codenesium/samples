using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("TeacherXTeacherSkill", Schema="dbo")]
        public partial class TeacherXTeacherSkill: AbstractEntity
        {
                public TeacherXTeacherSkill()
                {
                }

                public void SetProperties(
                        int id,
                        int teacherId,
                        int teacherSkillId)
                {
                        this.Id = id;
                        this.TeacherId = teacherId;
                        this.TeacherSkillId = teacherSkillId;
                }

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
    <Hash>4453605c129a9e64fa098e3e0cf451e6</Hash>
</Codenesium>*/