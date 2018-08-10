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
	public partial class ProxyRepository : AbstractProxyRepository, IProxyRepository
	{
		public ProxyRepository(
			ILogger<ProxyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>432627b6c4907c85b2ab8635bf38a97a</Hash>
</Codenesium>*/