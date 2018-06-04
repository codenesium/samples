using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class AWBuildVersionRepository: AbstractAWBuildVersionRepository, IAWBuildVersionRepository
	{
		public AWBuildVersionRepository(
			ILogger<AWBuildVersionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c0eeb9780e203bfc7bd42ac12626c6f8</Hash>
</Codenesium>*/