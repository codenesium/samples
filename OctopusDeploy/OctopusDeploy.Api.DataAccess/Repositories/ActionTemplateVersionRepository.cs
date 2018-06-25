using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ActionTemplateVersionRepository : AbstractActionTemplateVersionRepository, IActionTemplateVersionRepository
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
    <Hash>8e1dbeff33441d42563abc054563d753</Hash>
</Codenesium>*/