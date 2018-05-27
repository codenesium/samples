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
			IApiLessonStatusRequestModelValidator lessonStatusModelValidator,
			IBOLLessonStatusMapper lessonStatusMapper)
			: base(logger, lessonStatusRepository, lessonStatusModelValidator, lessonStatusMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8a4696f498aed6d9ce058f4397073f7e</Hash>
</Codenesium>*/