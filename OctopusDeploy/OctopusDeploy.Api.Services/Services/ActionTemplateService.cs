using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class ActionTemplateService : AbstractActionTemplateService, IActionTemplateService
        {
                public ActionTemplateService(
                        ILogger<IActionTemplateRepository> logger,
                        IActionTemplateRepository actionTemplateRepository,
                        IApiActionTemplateRequestModelValidator actionTemplateModelValidator,
                        IBOLActionTemplateMapper bolactionTemplateMapper,
                        IDALActionTemplateMapper dalactionTemplateMapper
                        )
                        : base(logger,
                               actionTemplateRepository,
                               actionTemplateModelValidator,
                               bolactionTemplateMapper,
                               dalactionTemplateMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>cde657bd9b370905487e614c3c95028a</Hash>
</Codenesium>*/