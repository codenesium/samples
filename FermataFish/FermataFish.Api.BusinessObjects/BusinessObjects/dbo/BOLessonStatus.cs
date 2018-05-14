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
	public class BOLessonStatus: AbstractBOLessonStatus, IBOLessonStatus
	{
		public BOLessonStatus(
			ILogger<LessonStatusRepository> logger,
			ILessonStatusRepository lessonStatusRepository,
			IApiLessonStatusModelValidator lessonStatusModelValidator)
			: base(logger, lessonStatusRepository, lessonStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d95e800e5d92564710336c6861d61e04</Hash>
</Codenesium>*/