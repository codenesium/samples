using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>fd0a43642391ffc534e67da0691472b6</Hash>
</Codenesium>*/