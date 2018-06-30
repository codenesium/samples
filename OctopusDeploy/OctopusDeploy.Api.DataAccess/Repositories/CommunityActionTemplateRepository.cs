using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class CommunityActionTemplateRepository : AbstractCommunityActionTemplateRepository, ICommunityActionTemplateRepository
        {
                public CommunityActionTemplateRepository(
                        ILogger<CommunityActionTemplateRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ee89c6c84238e367e60a283e5cc74cf7</Hash>
</Codenesium>*/