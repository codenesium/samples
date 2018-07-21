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

                [JsonProperty]
                public decimal AmountPerMinute { get; private set; }

                [JsonProperty]
                public int TeacherId { get; private set; }

                [JsonProperty]
                public int TeacherSkillId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e44c79b889d5b3fbc8ea7d5a0c6921f0</Hash>
</Codenesium>*/