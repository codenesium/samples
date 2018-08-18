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
    <Hash>7a90abafba2f72a6a4b8e468cf24e753</Hash>
</Codenesium>*/