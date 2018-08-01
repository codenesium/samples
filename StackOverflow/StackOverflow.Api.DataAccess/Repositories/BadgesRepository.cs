using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>9a904303065503982eb18924f1cf5e54</Hash>
</Codenesium>*/