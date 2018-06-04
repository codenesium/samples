using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
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
    <Hash>ebf4b3ba2ba996db53c04afcedab43a7</Hash>
</Codenesium>*/