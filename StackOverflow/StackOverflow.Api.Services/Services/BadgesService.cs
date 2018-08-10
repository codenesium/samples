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
	public partial class BadgesService : AbstractBadgesService, IBadgesService
	{
		public BadgesService(
			ILogger<IBadgesRepository> logger,
			IBadgesRepository badgesRepository,
			IApiBadgesRequestModelValidator badgesModelValidator,
			IBOLBadgesMapper bolbadgesMapper,
			IDALBadgesMapper dalbadgesMapper
			)
			: base(logger,
			       badgesRepository,
			       badgesModelValidator,
			       bolbadgesMapper,
			       dalbadgesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2134a4de87c34c0abb95b88950fafcb2</Hash>
</Codenesium>*/