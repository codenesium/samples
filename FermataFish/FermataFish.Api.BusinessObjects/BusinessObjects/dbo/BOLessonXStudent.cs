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
			ILessonXStudentModelValidator lessonXStudentModelValidator)
			: base(logger, lessonXStudentRepository, lessonXStudentModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>2f044d6875ab68c600163450924ee0af</Hash>
</Codenesium>*/