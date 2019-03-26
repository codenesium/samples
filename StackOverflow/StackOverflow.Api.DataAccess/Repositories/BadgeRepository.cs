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
	public partial class BadgeRepository : AbstractBadgeRepository, IBadgeRepository
	{
		public BadgeRepository(
			ILogger<BadgeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f9c69c59be38d947f011058e11079ee4</Hash>
</Codenesium>*/