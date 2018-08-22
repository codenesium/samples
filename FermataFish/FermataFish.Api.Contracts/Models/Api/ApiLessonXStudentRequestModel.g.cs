using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonXStudentRequestModel : AbstractApiRequestModel
	{
		public ApiLessonXStudentRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int lessonId,
			int studentId,
			int studioId)
		{
			this.LessonId = lessonId;
			this.StudentId = studentId;
			this.StudioId = studioId;
		}

		[Required]
		[JsonProperty]
		public int LessonId { get; private set; }

		[Required]
		[JsonProperty]
		public int StudentId { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a3645fbc85a585749a7b7e6cfecece04</Hash>
</Codenesium>*/