using Codenesium.DataConversionExtensions.AspNetCore;
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
        public class ChannelService : AbstractChannelService, IChannelService
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
    <Hash>ee7e607b89e3e69c6b7d3f2b2b602486</Hash>
</Codenesium>*/