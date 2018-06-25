using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiRateRequestModel : AbstractApiRequestModel
        {
                public ApiRateRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        decimal amountPerMinute,
                        int teacherId,
                        int teacherSkillId)
                {
                        this.AmountPerMinute = amountPerMinute;
                        this.TeacherId = teacherId;
                        this.TeacherSkillId = teacherSkillId;
                }

                private decimal amountPerMinute;

                [Required]
                public decimal AmountPerMinute
                {
                        get
                        {
                                return this.amountPerMinute;
                        }

                        set
                        {
                                this.amountPerMinute = value;
                        }
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
    <Hash>a7e35c11aa1d5e2e6a73ec8af99e4701</Hash>
</Codenesium>*/