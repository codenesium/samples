using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOLessonXTeacher: AbstractBusinessObject
        {
                public BOLessonXTeacher() : base()
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
    <Hash>880aeeda52b9f0394c859613e7ad8b3c</Hash>
</Codenesium>*/