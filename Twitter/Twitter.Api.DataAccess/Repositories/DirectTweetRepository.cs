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
	public partial class DirectTweetRepository : AbstractDirectTweetRepository, IDirectTweetRepository
	{
		public DirectTweetRepository(
			ILogger<DirectTweetRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>01065dca2283846a62bcbbe047ac2fd2</Hash>
</Codenesium>*/