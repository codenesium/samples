using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ServerTaskRepository : AbstractServerTaskRepository, IServerTaskRepository
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
    <Hash>7bb4a17d81d9847529fe80a3dbfb3c8d</Hash>
</Codenesium>*/