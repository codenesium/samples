using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class ChannelRepository : AbstractChannelRepository, IChannelRepository
	{
		public ChannelRepository(
			ILogger<ChannelRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2d87b52bdffe039aa10d68d80bafb49f</Hash>
</Codenesium>*/