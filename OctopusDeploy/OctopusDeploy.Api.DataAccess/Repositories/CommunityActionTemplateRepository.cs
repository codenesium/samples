using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class CommunityActionTemplateRepository : AbstractCommunityActionTemplateRepository, ICommunityActionTemplateRepository
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
    <Hash>c62df237ef32a2890a7274ba3beef8ec</Hash>
</Codenesium>*/