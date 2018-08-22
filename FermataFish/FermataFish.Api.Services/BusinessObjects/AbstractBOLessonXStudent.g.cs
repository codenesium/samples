using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOLessonXStudent : AbstractBusinessObject
	{
		public AbstractBOLessonXStudent()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int lessonId,
		                                  int studentId,
		                                  int studioId)
		{
			this.Id = id;
			this.LessonId = lessonId;
			this.StudentId = studentId;
			this.StudioId = studioId;
		}

		public int Id { get; private set; }

		public int LessonId { get; private set; }

		public int StudentId { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d6da7583a58119d7b8c7a1f94ed08075</Hash>
</Codenesium>*/