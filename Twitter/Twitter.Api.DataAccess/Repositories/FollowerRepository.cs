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
	public partial class FollowerRepository : AbstractFollowerRepository, IFollowerRepository
	{
		public FollowerRepository(
			ILogger<FollowerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8d3436c7b1900550a567632f79d030c0</Hash>
</Codenesium>*/