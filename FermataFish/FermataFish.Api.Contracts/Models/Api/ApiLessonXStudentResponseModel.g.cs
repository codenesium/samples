using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonXStudentResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int lessonId,
			int studentId,
			int studioId)
		{
			this.Id = id;
			this.LessonId = lessonId;
			this.StudentId = studentId;
			this.StudioId = studioId;

			this.LessonIdEntity = nameof(ApiResponse.Lessons);
			this.StudentIdEntity = nameof(ApiResponse.Students);
			this.StudioIdEntity = nameof(ApiResponse.Studios);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int LessonId { get; private set; }

		[JsonProperty]
		public string LessonIdEntity { get; set; }

		[JsonProperty]
		public int StudentId { get; private set; }

		[JsonProperty]
		public string StudentIdEntity { get; set; }

		[JsonProperty]
		public int StudioId { get; private set; }

		[JsonProperty]
		public string StudioIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>ce04b0230e085e43815985b110321287</Hash>
</Codenesium>*/