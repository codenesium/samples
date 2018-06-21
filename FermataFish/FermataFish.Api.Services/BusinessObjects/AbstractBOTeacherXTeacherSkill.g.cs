using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOTeacherXTeacherSkill : AbstractBusinessObject
        {
                public AbstractBOTeacherXTeacherSkill()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  int teacherId,
                                                  int teacherSkillId)
                {
                        this.Id = id;
                        this.TeacherId = teacherId;
                        this.TeacherSkillId = teacherSkillId;
                }

                public int Id { get; private set; }

                public int TeacherId { get; private set; }

                public int TeacherSkillId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>453685112eb95a233c55027d53c79304</Hash>
</Codenesium>*/