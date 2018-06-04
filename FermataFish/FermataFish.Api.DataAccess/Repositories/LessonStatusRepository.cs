using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class LessonStatusRepository: AbstractLessonStatusRepository, ILessonStatusRepository
	{
		public LessonStatusRepository(
			ILogger<LessonStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>4f5a20657f57488d3a6cb49ecbdd03c9</Hash>
</Codenesium>*/