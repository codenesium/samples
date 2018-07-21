using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiLessonXTeacherRequestModel : AbstractApiRequestModel
        {
                public ApiLessonXTeacherRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int lessonId,
                        int studentId)
                {
                        this.LessonId = lessonId;
                        this.StudentId = studentId;
                }

                [JsonProperty]
                public int LessonId { get; private set; }

                [JsonProperty]
                public int StudentId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>488140a5d6ad6fc988a83d72eeb46c80</Hash>
</Codenesium>*/