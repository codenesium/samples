using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
	public partial class FeedService : AbstractFeedService, IFeedService
	{
		public FeedService(
			ILogger<IFeedRepository> logger,
			IFeedRepository feedRepository,
			IApiFeedRequestModelValidator feedModelValidator,
			IBOLFeedMapper bolfeedMapper,
			IDALFeedMapper dalfeedMapper
			)
			: base(logger,
			       feedRepository,
			       feedModelValidator,
			       bolfeedMapper,
			       dalfeedMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d99265d6b649502634aa563866627379</Hash>
</Codenesium>*/