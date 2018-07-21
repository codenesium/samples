using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiTeacherXTeacherSkillResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int teacherId,
                        int teacherSkillId)
                {
                        this.Id = id;
                        this.TeacherId = teacherId;
                        this.TeacherSkillId = teacherSkillId;

                        this.TeacherIdEntity = nameof(ApiResponse.Teachers);
                        this.TeacherSkillIdEntity = nameof(ApiResponse.TeacherSkills);
                }

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
    <Hash>31a2fdb9dd1a599efeeacc80cd955510</Hash>
</Codenesium>*/