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
    <Hash>fe9f7cc54c3af616319879b589220de4</Hash>
</Codenesium>*/