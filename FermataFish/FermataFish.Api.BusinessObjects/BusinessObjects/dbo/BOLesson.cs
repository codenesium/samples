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
	public class BOLesson: AbstractBOLesson, IBOLesson
	{
		public BOLesson(
			ILogger<LessonRepository> logger,
			ILessonRepository lessonRepository,
			IApiLessonModelValidator lessonModelValidator)
			: base(logger, lessonRepository, lessonModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>7104ce685a7d9b9920b25426ab9f72e8</Hash>
</Codenesium>*/