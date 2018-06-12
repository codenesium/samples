using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ChannelRepository: AbstractChannelRepository, IChannelRepository
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
    <Hash>15094802c1b271ff3cfda1cdd2e24d4c</Hash>
</Codenesium>*/