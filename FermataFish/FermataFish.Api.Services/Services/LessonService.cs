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
	public class LessonService: AbstractLessonService, ILessonService
	{
		public LessonService(
			ILogger<LessonRepository> logger,
			ILessonRepository lessonRepository,
			IApiLessonRequestModelValidator lessonModelValidator,
			IBOLLessonMapper BOLlessonMapper,
			IDALLessonMapper DALlessonMapper)
			: base(logger, lessonRepository,
			       lessonModelValidator,
			       BOLlessonMapper,
			       DALlessonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>27a5f538793a2b491184857fc0d59977</Hash>
</Codenesium>*/