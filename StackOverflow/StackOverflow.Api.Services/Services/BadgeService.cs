using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial class BadgeService : AbstractBadgeService, IBadgeService
	{
		public BadgeService(
			ILogger<IBadgeRepository> logger,
			IBadgeRepository badgeRepository,
			IApiBadgeRequestModelValidator badgeModelValidator,
			IBOLBadgeMapper bolbadgeMapper,
			IDALBadgeMapper dalbadgeMapper)
			: base(logger,
			       badgeRepository,
			       badgeModelValidator,
			       bolbadgeMapper,
			       dalbadgeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b9f2c40b42d6d4dd400aed72fcc09b90</Hash>
</Codenesium>*/