using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonXTeacherResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int lessonId,
			int studentId)
		{
			this.Id = id;
			this.LessonId = lessonId;
			this.StudentId = studentId;

			this.LessonIdEntity = nameof(ApiResponse.Lessons);
			this.StudentIdEntity = nameof(ApiResponse.Students);
		}

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int LessonId { get; private set; }

		[JsonProperty]
		public string LessonIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public int StudentId { get; private set; }

		[JsonProperty]
		public string StudentIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>8b2ecc4be623d6109aa2b5c2bf95c6fe</Hash>
</Codenesium>*/