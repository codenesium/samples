using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOLessonXStudent: AbstractBusinessObject
        {
                public AbstractBOLessonXStudent() : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>452c2488f85da6ad3e6432533d612c96</Hash>
</Codenesium>*/