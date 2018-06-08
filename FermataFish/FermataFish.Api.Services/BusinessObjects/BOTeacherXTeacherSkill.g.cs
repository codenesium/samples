using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOTeacherXTeacherSkill: AbstractBusinessObject
        {
                public BOTeacherXTeacherSkill() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>67aaf4964bc8b9059603f7a8a453aff3</Hash>
</Codenesium>*/