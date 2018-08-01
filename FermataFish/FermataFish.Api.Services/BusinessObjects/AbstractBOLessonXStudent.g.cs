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
    <Hash>6578b0bc66570e578d22709dd3c4b1ef</Hash>
</Codenesium>*/