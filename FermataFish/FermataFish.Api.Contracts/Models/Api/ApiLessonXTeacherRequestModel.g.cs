using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiLessonXTeacherRequestModel: AbstractApiRequestModel
        {
                public ApiLessonXTeacherRequestModel() : base()
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
    <Hash>3088ee548f6fa91d10fd616161406917</Hash>
</Codenesium>*/