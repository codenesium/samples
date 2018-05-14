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
	public class BOLessonXStudent: AbstractBOLessonXStudent, IBOLessonXStudent
	{
		public BOLessonXStudent(
			ILogger<LessonXStudentRepository> logger,
			ILessonXStudentRepository lessonXStudentRepository,
			IApiLessonXStudentModelValidator lessonXStudentModelValidator)
			: base(logger, lessonXStudentRepository, lessonXStudentModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>3637e530dc62867c95381b605db687fe</Hash>
</Codenesium>*/