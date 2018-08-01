using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class ApiKeyRepository : AbstractApiKeyRepository, IApiKeyRepository
	{
		public ApiKeyRepository(
			ILogger<ApiKeyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b99c17d15fdc1713de5340c5d375c0bb</Hash>
</Codenesium>*/