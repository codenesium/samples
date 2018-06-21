using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
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
    <Hash>9bb78b1ef4c1dc89007644aa5ae03705</Hash>
</Codenesium>*/