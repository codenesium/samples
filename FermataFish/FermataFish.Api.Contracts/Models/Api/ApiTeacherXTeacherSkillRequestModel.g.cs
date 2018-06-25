using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiTeacherXTeacherSkillRequestModel : AbstractApiRequestModel
        {
                public ApiTeacherXTeacherSkillRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int teacherId,
                        int teacherSkillId)
                {
                        this.TeacherId = teacherId;
                        this.TeacherSkillId = teacherSkillId;
                }

                private int teacherId;

                [Required]
                public int TeacherId
                {
                        get
                        {
                                return this.teacherId;
                        }

                        set
                        {
                                this.teacherId = value;
                        }
                }

                private int teacherSkillId;

                [Required]
                public int TeacherSkillId
                {
                        get
                        {
                                return this.teacherSkillId;
                        }

                        set
                        {
                                this.teacherSkillId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f062c317a608b13c0d18d08f85a92717</Hash>
</Codenesium>*/