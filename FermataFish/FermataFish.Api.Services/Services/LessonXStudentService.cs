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
	public class LessonXStudentService: AbstractLessonXStudentService, ILessonXStudentService
	{
		public LessonXStudentService(
			ILogger<LessonXStudentRepository> logger,
			ILessonXStudentRepository lessonXStudentRepository,
			IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator,
			IBOLLessonXStudentMapper BOLlessonXStudentMapper,
			IDALLessonXStudentMapper DALlessonXStudentMapper)
			: base(logger, lessonXStudentRepository,
			       lessonXStudentModelValidator,
			       BOLlessonXStudentMapper,
			       DALlessonXStudentMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>99c9b2c8be124f2eae94ec34ce131400</Hash>
</Codenesium>*/