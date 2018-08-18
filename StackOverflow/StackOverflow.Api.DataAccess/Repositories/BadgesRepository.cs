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
    <Hash>287557b32dc581045386e1f89a13b291</Hash>
</Codenesium>*/