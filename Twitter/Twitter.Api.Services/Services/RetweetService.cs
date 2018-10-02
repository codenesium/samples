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
			IDALRetweetMapper dalretweetMapper
			)
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
    <Hash>e6206f055ff5c52e55217b739cdcd7c3</Hash>
</Codenesium>*/