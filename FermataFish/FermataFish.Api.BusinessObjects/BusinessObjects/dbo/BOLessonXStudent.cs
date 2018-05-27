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
			IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator,
			IBOLLessonXStudentMapper lessonXStudentMapper)
			: base(logger, lessonXStudentRepository, lessonXStudentModelValidator, lessonXStudentMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>1fcae51031e993f0f07d17657417f955</Hash>
</Codenesium>*/