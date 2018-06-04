using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class LessonXTeacherRepository: AbstractLessonXTeacherRepository, ILessonXTeacherRepository
	{
		public LessonXTeacherRepository(
			ILogger<LessonXTeacherRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>291766f7a7ebbf72555817ab6643e8f2</Hash>
</Codenesium>*/