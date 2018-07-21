using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                [JsonProperty]
                public int TeacherId { get; private set; }

                [JsonProperty]
                public int TeacherSkillId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c3e87bed2113444b302573d905eb7104</Hash>
</Codenesium>*/