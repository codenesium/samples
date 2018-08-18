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
    <Hash>0efa6d3d2c355c277d010391c484ce89</Hash>
</Codenesium>*/