using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonXTeacherModel: AbstractModel
	{
		public ApiLessonXTeacherModel() : base()
		{}

		public ApiLessonXTeacherModel(
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
    <Hash>5c82fcb3137683156c1ef942462d4335</Hash>
</Codenesium>*/