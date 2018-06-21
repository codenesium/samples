using Codenesium.DataConversionExtensions;
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
    <Hash>231e3930af9c540befc1205783ea8db8</Hash>
</Codenesium>*/