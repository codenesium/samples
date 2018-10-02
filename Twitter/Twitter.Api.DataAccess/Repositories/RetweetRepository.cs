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
	public partial class RetweetRepository : AbstractRetweetRepository, IRetweetRepository
	{
		public RetweetRepository(
			ILogger<RetweetRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5521dad20658cedd0342007487bc5ca9</Hash>
</Codenesium>*/