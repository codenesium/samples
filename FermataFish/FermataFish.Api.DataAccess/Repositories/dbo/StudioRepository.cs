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
	public class StudioRepository: AbstractStudioRepository, IStudioRepository
	{
		public StudioRepository(
			IDALStudioMapper mapper,
			ILogger<StudioRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>1eaf898dffc37f0cdab51cd236f1bf98</Hash>
</Codenesium>*/