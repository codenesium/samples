using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonXTeacherRequestModel : AbstractApiRequestModel
	{
		public ApiLessonXTeacherRequestModel()
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
    <Hash>e66c9c2bed814bd5932f2a226a1ffab8</Hash>
</Codenesium>*/