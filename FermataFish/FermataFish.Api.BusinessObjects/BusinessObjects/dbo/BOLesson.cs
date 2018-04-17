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
			ILessonModelValidator lessonModelValidator)
			: base(logger, lessonRepository, lessonModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>81bf3ca7af4d3dee6893fd5072226c3c</Hash>
</Codenesium>*/