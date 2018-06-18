using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOTeacherXTeacherSkill: AbstractBusinessObject
        {
                public AbstractBOTeacherXTeacherSkill() : base()
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
    <Hash>4b77a2fb5245c1866e0e769cc927566d</Hash>
</Codenesium>*/