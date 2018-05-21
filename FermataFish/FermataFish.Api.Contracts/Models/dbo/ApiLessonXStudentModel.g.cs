using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonXStudentModel: AbstractModel
	{
		public ApiLessonXStudentModel() : base()
		{}

		public ApiLessonXStudentModel(
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
    <Hash>488cd70b607afa61424902b6cc982a5c</Hash>
</Codenesium>*/