using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ServerTaskRepository: AbstractServerTaskRepository, IServerTaskRepository
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
    <Hash>858f206515b65e3f585dcccf849b729c</Hash>
</Codenesium>*/