using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class OctopusServerNodeRepository : AbstractOctopusServerNodeRepository, IOctopusServerNodeRepository
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
    <Hash>86f27f4293f6944a89e52aa7ecfde348</Hash>
</Codenesium>*/