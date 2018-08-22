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

		[Required]
		[JsonProperty]
		public int LessonId { get; private set; }

		[Required]
		[JsonProperty]
		public int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0fe58fefb7dc50756ff382a4cc083fd1</Hash>
</Codenesium>*/