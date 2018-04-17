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
			ILessonXTeacherModelValidator lessonXTeacherModelValidator)
			: base(logger, lessonXTeacherRepository, lessonXTeacherModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>07576cc22ac90acb8b7f1c1e78624e20</Hash>
</Codenesium>*/