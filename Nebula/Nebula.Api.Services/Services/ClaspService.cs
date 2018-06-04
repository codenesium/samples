using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public class ClaspService: AbstractClaspService, IClaspService
	{
		public ClaspService(
			ILogger<ClaspRepository> logger,
			IClaspRepository claspRepository,
			IApiClaspRequestModelValidator claspModelValidator,
			IBOLClaspMapper BOLclaspMapper,
			IDALClaspMapper DALclaspMapper)
			: base(logger, claspRepository,
			       claspModelValidator,
			       BOLclaspMapper,
			       DALclaspMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b3fffbf2eb58108234051083bae9fda7</Hash>
</Codenesium>*/