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
	public partial class ChannelService : AbstractChannelService, IChannelService
	{
		public ChannelService(
			ILogger<IChannelRepository> logger,
			IChannelRepository channelRepository,
			IApiChannelRequestModelValidator channelModelValidator,
			IBOLChannelMapper bolchannelMapper,
			IDALChannelMapper dalchannelMapper
			)
			: base(logger,
			       channelRepository,
			       channelModelValidator,
			       bolchannelMapper,
			       dalchannelMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bad432810ae9bb85e89fa7d88873006c</Hash>
</Codenesium>*/