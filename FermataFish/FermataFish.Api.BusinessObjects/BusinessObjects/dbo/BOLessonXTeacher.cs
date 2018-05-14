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
			IApiLessonXTeacherModelValidator lessonXTeacherModelValidator)
			: base(logger, lessonXTeacherRepository, lessonXTeacherModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>49ced99953d1f87102a19fa476667567</Hash>
</Codenesium>*/