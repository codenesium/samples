using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOLessonXTeacher: AbstractBusinessObject
        {
                public AbstractBOLessonXTeacher() : base()
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
    <Hash>0bd842ba77a39320b04b5785438abf34</Hash>
</Codenesium>*/