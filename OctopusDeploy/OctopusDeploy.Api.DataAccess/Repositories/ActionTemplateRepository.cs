using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ActionTemplateRepository : AbstractActionTemplateRepository, IActionTemplateRepository
        {
                public ActionTemplateRepository(
                        ILogger<ActionTemplateRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2a4a77506ae19c90c1baa16f63bf6886</Hash>
</Codenesium>*/