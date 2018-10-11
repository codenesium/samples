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
	public partial class RetweetService : AbstractRetweetService, IRetweetService
	{
		public RetweetService(
			ILogger<IRetweetRepository> logger,
			IRetweetRepository retweetRepository,
			IApiRetweetRequestModelValidator retweetModelValidator,
			IBOLRetweetMapper bolretweetMapper,
			IDALRetweetMapper dalretweetMapper)
			: base(logger,
			       retweetRepository,
			       retweetModelValidator,
			       bolretweetMapper,
			       dalretweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>03623360635ada38f003acbc6550a7ee</Hash>
</Codenesium>*/