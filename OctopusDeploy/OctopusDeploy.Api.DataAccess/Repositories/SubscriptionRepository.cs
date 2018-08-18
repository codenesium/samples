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
    <Hash>2884df77630a4b138038950d04692bf0</Hash>
</Codenesium>*/