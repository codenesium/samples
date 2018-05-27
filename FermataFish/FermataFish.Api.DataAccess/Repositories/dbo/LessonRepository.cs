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
	public class LessonRepository: AbstractLessonRepository, ILessonRepository
	{
		public LessonRepository(
			IDALLessonMapper mapper,
			ILogger<LessonRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ea2ff30db8fd91563e7d237b4a54bf31</Hash>
</Codenesium>*/