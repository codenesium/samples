using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiLessonXStudentRequestModel : AbstractApiRequestModel
        {
                public ApiLessonXStudentRequestModel()
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
    <Hash>ea75564936ef288bf1462933c1a0a262</Hash>
</Codenesium>*/