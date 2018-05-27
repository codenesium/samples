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
	public class LessonStatusRepository: AbstractLessonStatusRepository, ILessonStatusRepository
	{
		public LessonStatusRepository(
			IDALLessonStatusMapper mapper,
			ILogger<LessonStatusRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>11d8735a1e12f6ecd9baf0bf44fdca06</Hash>
</Codenesium>*/