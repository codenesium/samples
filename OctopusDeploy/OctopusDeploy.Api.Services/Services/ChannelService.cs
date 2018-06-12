using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ChannelService: AbstractChannelService, IChannelService
        {
                public ChannelService(
                        ILogger<ChannelRepository> logger,
                        IChannelRepository channelRepository,
                        IApiChannelRequestModelValidator channelModelValidator,
                        IBOLChannelMapper bolchannelMapper,
                        IDALChannelMapper dalchannelMapper)
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
    <Hash>404906d45623d39e73ef389da40a9572</Hash>
</Codenesium>*/