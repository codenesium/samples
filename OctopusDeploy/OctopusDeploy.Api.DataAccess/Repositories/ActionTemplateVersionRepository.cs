using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ActionTemplateVersionRepository: AbstractActionTemplateVersionRepository, IActionTemplateVersionRepository
        {
                public ActionTemplateVersionRepository(
                        ILogger<ActionTemplateVersionRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f42e714d32799804f97c2096186d658a</Hash>
</Codenesium>*/