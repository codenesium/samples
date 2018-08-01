using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class ReleaseRepository : AbstractReleaseRepository, IReleaseRepository
	{
		public ReleaseRepository(
			ILogger<ReleaseRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a4c0a9fa58f1e9d57840243b29aeb6f8</Hash>
</Codenesium>*/