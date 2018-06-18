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
                               dalchannelMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>533f56682888e57fa09c74576df1f6a3</Hash>
</Codenesium>*/