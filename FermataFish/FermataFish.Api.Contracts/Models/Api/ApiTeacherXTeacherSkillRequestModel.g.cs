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
    <Hash>ea2bc00a28a81f23f5b61b5d00e0176a</Hash>
</Codenesium>*/