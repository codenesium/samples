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
			IDALFollowingMapper dalfollowingMapper)
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
    <Hash>f1acff619ee4cdba188f25ee0720c5d2</Hash>
</Codenesium>*/