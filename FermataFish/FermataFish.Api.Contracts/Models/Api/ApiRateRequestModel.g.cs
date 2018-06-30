using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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
    <Hash>44e8fc6d055d2db0be3e9500b868d6ca</Hash>
</Codenesium>*/