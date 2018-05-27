using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonXStudentRequestModel: AbstractApiRequestModel
	{
		public ApiLessonXStudentRequestModel() : base()
		{}

		public void SetProperties(
			int lessonId,
			int studentId)
		{
			this.LessonId = lessonId.ToInt();
			this.StudentId = studentId.ToInt();
		}

		private int lessonId;

		[Required]
		public int LessonId
		{
			get
			{
				return this.lessonId;
			}

			set
			{
				this.lessonId = value;
			}
		}

		private int studentId;

		[Required]
		public int StudentId
		{
			get
			{
				return this.studentId;
			}

			set
			{
				this.studentId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>5587304fba4ba0121d0291e260d9f049</Hash>
</Codenesium>*/