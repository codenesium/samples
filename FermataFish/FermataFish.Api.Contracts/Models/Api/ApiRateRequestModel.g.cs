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

                public void SetProperties(
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
    <Hash>46f35855204ce348b17073dffe9f99cf</Hash>
</Codenesium>*/