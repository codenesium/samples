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
    <Hash>3b53ea6b22aefe1e4d2970882ed620ea</Hash>
</Codenesium>*/