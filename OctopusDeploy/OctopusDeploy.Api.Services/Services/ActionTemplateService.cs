using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ActionTemplateService: AbstractActionTemplateService, IActionTemplateService
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
                               dalactionTemplateMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>c43ac4b632149899c7ef6eab497a2c5d</Hash>
</Codenesium>*/