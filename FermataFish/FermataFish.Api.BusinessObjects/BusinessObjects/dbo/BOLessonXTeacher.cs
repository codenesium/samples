using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class BOLessonXTeacher: AbstractBOLessonXTeacher, IBOLessonXTeacher
	{
		public BOLessonXTeacher(
			ILogger<LessonXTeacherRepository> logger,
			ILessonXTeacherRepository lessonXTeacherRepository,
			IApiLessonXTeacherRequestModelValidator lessonXTeacherModelValidator,
			IBOLLessonXTeacherMapper lessonXTeacherMapper)
			: base(logger, lessonXTeacherRepository, lessonXTeacherModelValidator, lessonXTeacherMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b6d4fc517a85a393fcf4c1ae2972121a</Hash>
</Codenesium>*/