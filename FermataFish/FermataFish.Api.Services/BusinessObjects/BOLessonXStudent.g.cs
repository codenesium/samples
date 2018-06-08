using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOLessonXStudent: AbstractBusinessObject
        {
                public BOLessonXStudent() : base()
                {
                }

                public void SetProperties(int id,
                                          int lessonId,
                                          int studentId)
                {
                        this.Id = id;
                        this.LessonId = lessonId;
                        this.StudentId = studentId;
                }

                public int Id { get; private set; }

                public int LessonId { get; private set; }

                public int StudentId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>582b80bcf27d85ebc07fcf02a694fb82</Hash>
</Codenesium>*/