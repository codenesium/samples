using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>93111622486806312d134386c7e29cc8</Hash>
</Codenesium>*/