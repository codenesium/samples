using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class BadgesRepository : AbstractBadgesRepository, IBadgesRepository
	{
		public BadgesRepository(
			ILogger<BadgesRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0a10335416f95f89b91ffa4e825a492c</Hash>
</Codenesium>*/