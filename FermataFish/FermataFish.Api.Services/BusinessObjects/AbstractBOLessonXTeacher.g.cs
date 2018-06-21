using Codenesium.DataConversionExtensions;
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
    <Hash>a9247a181472be099b319a6b88ef3331</Hash>
</Codenesium>*/