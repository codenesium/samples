using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class OctopusServerNodeRepository : AbstractOctopusServerNodeRepository, IOctopusServerNodeRepository
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
    <Hash>ab2bbfd1df315806808c0af160f9b1fa</Hash>
</Codenesium>*/