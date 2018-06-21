using Codenesium.DataConversionExtensions;
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
    <Hash>7e73e32a0b2b12917285e9038466e678</Hash>
</Codenesium>*/