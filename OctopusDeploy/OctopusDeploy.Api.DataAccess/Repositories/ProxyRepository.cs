using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>5a797581ad5b8e6e1a23b1d3894b0981</Hash>
</Codenesium>*/