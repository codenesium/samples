using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial class FollowingRepository : AbstractFollowingRepository, IFollowingRepository
	{
		public FollowingRepository(
			ILogger<FollowingRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>03c25833cb0624dd8f7763c9f57a121a</Hash>
</Codenesium>*/