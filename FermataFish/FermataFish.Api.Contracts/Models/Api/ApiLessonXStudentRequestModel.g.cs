using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
                        int lessonId,
                        int studentId)
                {
                        this.LessonId = lessonId;
                        this.StudentId = studentId;
                }

                private int lessonId;

                [Required]
                public int LessonId
                {
                        get
                        {
                                return this.lessonId;
                        }

                        set
                        {
                                this.lessonId = value;
                        }
                }

                private int studentId;

                [Required]
                public int StudentId
                {
                        get
                        {
                                return this.studentId;
                        }

                        set
                        {
                                this.studentId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>06adf4db8bff0b21f991c9a87aa5634c</Hash>
</Codenesium>*/