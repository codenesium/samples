using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class FollowerService : AbstractFollowerService, IFollowerService
	{
		public FollowerService(
			ILogger<IFollowerRepository> logger,
			IFollowerRepository followerRepository,
			IApiFollowerRequestModelValidator followerModelValidator,
			IBOLFollowerMapper bolfollowerMapper,
			IDALFollowerMapper dalfollowerMapper)
			: base(logger,
			       followerRepository,
			       followerModelValidator,
			       bolfollowerMapper,
			       dalfollowerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>adadf42ace19a3e3eb3ef73a62b82cf2</Hash>
</Codenesium>*/