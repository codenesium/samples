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
    <Hash>0f9b8fde2b26e3daaa21cbc5f3523b22</Hash>
</Codenesium>*/