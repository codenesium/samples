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
	public partial class FollowingService : AbstractFollowingService, IFollowingService
	{
		public FollowingService(
			ILogger<IFollowingRepository> logger,
			IFollowingRepository followingRepository,
			IApiFollowingRequestModelValidator followingModelValidator,
			IBOLFollowingMapper bolfollowingMapper,
			IDALFollowingMapper dalfollowingMapper
			)
			: base(logger,
			       followingRepository,
			       followingModelValidator,
			       bolfollowingMapper,
			       dalfollowingMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c8e134eacd45d9f731d723d04b48f58d</Hash>
</Codenesium>*/