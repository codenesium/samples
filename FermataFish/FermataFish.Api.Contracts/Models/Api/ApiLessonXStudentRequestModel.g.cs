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
			int studentId)
		{
			this.LessonId = lessonId;
			this.StudentId = studentId;
		}

		[JsonProperty]
		public int LessonId { get; private set; }

		[JsonProperty]
		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>699a72442bc25b5ea04fb17cf96acdfc</Hash>
</Codenesium>*/