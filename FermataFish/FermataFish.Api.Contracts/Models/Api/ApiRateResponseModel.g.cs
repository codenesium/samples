using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiRateResponseModel: AbstractApiResponseModel
        {
                public ApiRateResponseModel() : base()
                {
                }

                public void SetProperties(
                        decimal amountPerMinute,
                        int id,
                        int teacherId,
                        int teacherSkillId)
                {
                        this.AmountPerMinute = amountPerMinute;
                        this.Id = id;
                        this.TeacherId = teacherId;
                        this.TeacherSkillId = teacherSkillId;

                        this.TeacherIdEntity = nameof(ApiResponse.Teachers);
                        this.TeacherSkillIdEntity = nameof(ApiResponse.TeacherSkills);
                }

                public decimal AmountPerMinute { get; private set; }

                public int Id { get; private set; }

                public int TeacherId { get; private set; }

                public string TeacherIdEntity { get; set; }

                public int TeacherSkillId { get; private set; }

                public string TeacherSkillIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeAmountPerMinuteValue { get; set; } = true;

                public bool ShouldSerializeAmountPerMinute()
                {
                        return this.ShouldSerializeAmountPerMinuteValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTeacherIdValue { get; set; } = true;

                public bool ShouldSerializeTeacherId()
                {
                        return this.ShouldSerializeTeacherIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTeacherSkillIdValue { get; set; } = true;

                public bool ShouldSerializeTeacherSkillId()
                {
                        return this.ShouldSerializeTeacherSkillIdValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeAmountPerMinuteValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeTeacherIdValue = false;
                        this.ShouldSerializeTeacherSkillIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>302fd28d64b54ecd5359faaab6ee17eb</Hash>
</Codenesium>*/