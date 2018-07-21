using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiRateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        decimal amountPerMinute,
                        int teacherId,
                        int teacherSkillId)
                {
                        this.Id = id;
                        this.AmountPerMinute = amountPerMinute;
                        this.TeacherId = teacherId;
                        this.TeacherSkillId = teacherSkillId;

                        this.TeacherIdEntity = nameof(ApiResponse.Teachers);
                        this.TeacherSkillIdEntity = nameof(ApiResponse.TeacherSkills);
                }

                [Required]
                [JsonProperty]
                public decimal AmountPerMinute { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int TeacherId { get; private set; }

                [JsonProperty]
                public string TeacherIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int TeacherSkillId { get; private set; }

                [JsonProperty]
                public string TeacherSkillIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>bd87dd99ab473b3d75703828dea83fa8</Hash>
</Codenesium>*/