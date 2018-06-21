using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ChannelRepository : AbstractChannelRepository, IChannelRepository
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
    <Hash>1aff53e904601b355870c8e39e1d4978</Hash>
</Codenesium>*/