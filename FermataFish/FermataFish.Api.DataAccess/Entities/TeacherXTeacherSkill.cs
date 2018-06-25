using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("TeacherXTeacherSkill", Schema="dbo")]
        public partial class TeacherXTeacherSkill : AbstractEntity
        {
                public TeacherXTeacherSkill()
                {
                }

                public virtual void SetProperties(
                        int id,
                        int teacherId,
                        int teacherSkillId)
                {
                        this.Id = id;
                        this.TeacherId = teacherId;
                        this.TeacherSkillId = teacherSkillId;
                }

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
    <Hash>61ca2829088a6fc00f0f84eccbdbd715</Hash>
</Codenesium>*/