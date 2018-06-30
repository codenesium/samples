using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ServerTaskRepository : AbstractServerTaskRepository, IServerTaskRepository
        {
                public ServerTaskRepository(
                        ILogger<ServerTaskRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>04509c77b02576812f1b288729a093e0</Hash>
</Codenesium>*/