using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ActionTemplateRepository: AbstractActionTemplateRepository, IActionTemplateRepository
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
    <Hash>9b150343d4566a27b6891bafa18c3ae7</Hash>
</Codenesium>*/