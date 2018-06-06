using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
	public partial class BOLessonXTeacher: AbstractBusinessObject
	{
		public BOLessonXTeacher() : base()
		{}

		public void SetProperties(int id,
		                          int lessonId,
		                          int studentId)
		{
			this.Id = id.ToInt();
			this.LessonId = lessonId.ToInt();
			this.StudentId = studentId.ToInt();
		}

		public int Id { get; private set; }
		public int LessonId { get; private set; }
		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>32c77fdb4bc4f0c8f56a2e98027eda4f</Hash>
</Codenesium>*/