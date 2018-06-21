using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOLessonXTeacher : AbstractBusinessObject
        {
                public AbstractBOLessonXTeacher()
                        : base()
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
    <Hash>6abda923b91928cfbd5dad6c9356a0fe</Hash>
</Codenesium>*/