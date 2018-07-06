using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiLessonXTeacherResponseModel : AbstractApiResponseModel
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
        }
}

/*<Codenesium>
    <Hash>b2e33c0f3e951b1cbb941a5a54331225</Hash>
</Codenesium>*/