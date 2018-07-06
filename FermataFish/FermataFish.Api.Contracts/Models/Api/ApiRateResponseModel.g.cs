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

                public decimal AmountPerMinute { get; private set; }

                public int Id { get; private set; }

                public int TeacherId { get; private set; }

                public string TeacherIdEntity { get; set; }

                public int TeacherSkillId { get; private set; }

                public string TeacherSkillIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>f4ad134710809ef474e93c699f17bfbd</Hash>
</Codenesium>*/