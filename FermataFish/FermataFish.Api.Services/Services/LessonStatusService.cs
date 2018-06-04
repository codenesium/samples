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
	public class LessonStatusService: AbstractLessonStatusService, ILessonStatusService
	{
		public LessonStatusService(
			ILogger<LessonStatusRepository> logger,
			ILessonStatusRepository lessonStatusRepository,
			IApiLessonStatusRequestModelValidator lessonStatusModelValidator,
			IBOLLessonStatusMapper BOLlessonStatusMapper,
			IDALLessonStatusMapper DALlessonStatusMapper)
			: base(logger, lessonStatusRepository,
			       lessonStatusModelValidator,
			       BOLlessonStatusMapper,
			       DALlessonStatusMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>588c2c2697748100f89ccc0954f1ba56</Hash>
</Codenesium>*/