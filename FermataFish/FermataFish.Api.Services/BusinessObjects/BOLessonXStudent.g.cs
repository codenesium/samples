using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
	public partial class BOLessonXStudent: AbstractBusinessObject
	{
		public BOLessonXStudent() : base()
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
    <Hash>1cd01606c6423819d7b4cf04e7c2e1ee</Hash>
</Codenesium>*/