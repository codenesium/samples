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
	public partial class SubscriptionRepository : AbstractSubscriptionRepository, ISubscriptionRepository
	{
		public SubscriptionRepository(
			ILogger<SubscriptionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>631fa4fa640775fb95750f39e11dc18a</Hash>
</Codenesium>*/