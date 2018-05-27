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
			IApiLessonRequestModelValidator lessonModelValidator,
			IBOLLessonMapper lessonMapper)
			: base(logger, lessonRepository, lessonModelValidator, lessonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>0b2942bd1f6b1d45200ce0135e3be5fb</Hash>
</Codenesium>*/