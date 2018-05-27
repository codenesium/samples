using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOLessonXTeacher: AbstractDTO
	{
		public DTOLessonXTeacher() : base()
		{}

		public void SetProperties(int id,
		                          int lessonId,
		                          int studentId)
		{
			this.Id = id.ToInt();
			this.LessonId = lessonId.ToInt();
			this.StudentId = studentId.ToInt();
		}

		public int Id { get; set; }
		public int LessonId { get; set; }
		public int StudentId { get; set; }
	}
}

/*<Codenesium>
    <Hash>db10a6396bb5f5fe5bff7f3df83b62fd</Hash>
</Codenesium>*/