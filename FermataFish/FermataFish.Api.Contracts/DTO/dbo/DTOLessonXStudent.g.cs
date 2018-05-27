using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOLessonXStudent: AbstractDTO
	{
		public DTOLessonXStudent() : base()
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
    <Hash>f83a0d5c798bf260a179769de8b99eb8</Hash>
</Codenesium>*/