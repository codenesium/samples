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

                public int Id { get; private set; }

                public int TeacherId { get; private set; }

                public string TeacherIdEntity { get; set; }

                public int TeacherSkillId { get; private set; }

                public string TeacherSkillIdEntity { get; set; }

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

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeTeacherIdValue = false;
                        this.ShouldSerializeTeacherSkillIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>1535abce1aeec46dfb44fe233387ee9a</Hash>
</Codenesium>*/