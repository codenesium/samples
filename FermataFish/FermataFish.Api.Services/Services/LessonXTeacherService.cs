using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class LessonXTeacherService: AbstractLessonXTeacherService, ILessonXTeacherService
	{
		public LessonXTeacherService(
			ILogger<LessonXTeacherRepository> logger,
			ILessonXTeacherRepository lessonXTeacherRepository,
			IApiLessonXTeacherRequestModelValidator lessonXTeacherModelValidator,
			IBOLLessonXTeacherMapper BOLlessonXTeacherMapper,
			IDALLessonXTeacherMapper DALlessonXTeacherMapper)
			: base(logger, lessonXTeacherRepository,
			       lessonXTeacherModelValidator,
			       BOLlessonXTeacherMapper,
			       DALlessonXTeacherMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>20cea03e0ea0cd39888141c27be53446</Hash>
</Codenesium>*/