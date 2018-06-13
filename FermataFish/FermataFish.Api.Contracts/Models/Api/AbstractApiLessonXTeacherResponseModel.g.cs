using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiLessonXTeacherResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int lessonId,
                        int studentId)
                {
                        this.Id = id;
                        this.LessonId = lessonId;
                        this.StudentId = studentId;

                        this.LessonIdEntity = nameof(ApiResponse.Lessons);
                        this.StudentIdEntity = nameof(ApiResponse.Students);
                }

                public int Id { get; private set; }

                public int LessonId { get; private set; }

                public string LessonIdEntity { get; set; }

                public int StudentId { get; private set; }

                public string StudentIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLessonIdValue { get; set; } = true;

                public bool ShouldSerializeLessonId()
                {
                        return this.ShouldSerializeLessonIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStudentIdValue { get; set; } = true;

                public bool ShouldSerializeStudentId()
                {
                        return this.ShouldSerializeStudentIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLessonIdValue = false;
                        this.ShouldSerializeStudentIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>782285026429caa81302d88439a851a2</Hash>
</Codenesium>*/