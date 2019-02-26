using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.DataAccess
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
    <Hash>e273cac2e6b6cf8546d9018f856c0bee</Hash>
</Codenesium>*/