using Codenesium.DataConversionExtensions;
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
    <Hash>b1e26f223552eba65f8754d71ce0ee89</Hash>
</Codenesium>*/