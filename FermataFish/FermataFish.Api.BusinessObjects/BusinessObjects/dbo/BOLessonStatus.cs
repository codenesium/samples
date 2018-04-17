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
			ILessonStatusModelValidator lessonStatusModelValidator)
			: base(logger, lessonStatusRepository, lessonStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>dc01974e0bebacb5de8bb2017e0c1de9</Hash>
</Codenesium>*/