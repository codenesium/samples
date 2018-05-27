using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class LessonXTeacherRepository: AbstractLessonXTeacherRepository, ILessonXTeacherRepository
	{
		public LessonXTeacherRepository(
			IDALLessonXTeacherMapper mapper,
			ILogger<LessonXTeacherRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3dd55f52622bb631afe6fad2b6571c56</Hash>
</Codenesium>*/