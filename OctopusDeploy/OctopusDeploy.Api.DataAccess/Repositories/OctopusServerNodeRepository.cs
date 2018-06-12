using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class OctopusServerNodeRepository: AbstractOctopusServerNodeRepository, IOctopusServerNodeRepository
        {
                public OctopusServerNodeRepository(
                        ILogger<OctopusServerNodeRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>48df1e6baba53f2a0de5b549d83dbafd</Hash>
</Codenesium>*/