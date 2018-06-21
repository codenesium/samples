using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>0b175b7a3a23ba588649fc72487a9304</Hash>
</Codenesium>*/