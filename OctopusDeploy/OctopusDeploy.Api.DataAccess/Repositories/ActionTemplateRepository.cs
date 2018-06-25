using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ActionTemplateRepository : AbstractActionTemplateRepository, IActionTemplateRepository
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
    <Hash>0e3ac27847dbe3109da1d0e8805be556</Hash>
</Codenesium>*/