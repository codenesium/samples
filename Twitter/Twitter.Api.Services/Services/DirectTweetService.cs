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
	public partial class DirectTweetService : AbstractDirectTweetService, IDirectTweetService
	{
		public DirectTweetService(
			ILogger<IDirectTweetRepository> logger,
			IDirectTweetRepository directTweetRepository,
			IApiDirectTweetRequestModelValidator directTweetModelValidator,
			IBOLDirectTweetMapper boldirectTweetMapper,
			IDALDirectTweetMapper daldirectTweetMapper
			)
			: base(logger,
			       directTweetRepository,
			       directTweetModelValidator,
			       boldirectTweetMapper,
			       daldirectTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d180c197e24062cbf576c0eb2e92bdc4</Hash>
</Codenesium>*/