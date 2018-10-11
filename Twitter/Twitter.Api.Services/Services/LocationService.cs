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
	public partial class LocationService : AbstractLocationService, ILocationService
	{
		public LocationService(
			ILogger<ILocationRepository> logger,
			ILocationRepository locationRepository,
			IApiLocationRequestModelValidator locationModelValidator,
			IBOLLocationMapper bollocationMapper,
			IDALLocationMapper dallocationMapper,
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper)
			: base(logger,
			       locationRepository,
			       locationModelValidator,
			       bollocationMapper,
			       dallocationMapper,
			       bolTweetMapper,
			       dalTweetMapper,
			       bolUserMapper,
			       dalUserMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>82513f9ca528f9a1b01069c77b5e52ba</Hash>
</Codenesium>*/