using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
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
    <Hash>425537ba45b4dd7c5d3f3e2deaef424f</Hash>
</Codenesium>*/