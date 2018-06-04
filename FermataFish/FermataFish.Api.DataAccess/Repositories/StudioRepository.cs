using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class StudioRepository: AbstractStudioRepository, IStudioRepository
	{
		public StudioRepository(
			ILogger<StudioRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>1554794791cd963da0f483437b3fc935</Hash>
</Codenesium>*/