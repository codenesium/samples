using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>0bdf361219c68a5a39e2d8ef2a565bb8</Hash>
</Codenesium>*/