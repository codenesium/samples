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
        public class ActionTemplateVersionService: AbstractActionTemplateVersionService, IActionTemplateVersionService
        {
                public ActionTemplateVersionService(
                        ILogger<ActionTemplateVersionRepository> logger,
                        IActionTemplateVersionRepository actionTemplateVersionRepository,
                        IApiActionTemplateVersionRequestModelValidator actionTemplateVersionModelValidator,
                        IBOLActionTemplateVersionMapper bolactionTemplateVersionMapper,
                        IDALActionTemplateVersionMapper dalactionTemplateVersionMapper

                        )
                        : base(logger,
                               actionTemplateVersionRepository,
                               actionTemplateVersionModelValidator,
                               bolactionTemplateVersionMapper,
                               dalactionTemplateVersionMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>b90ce22895f08fdd98d879a7a401ff28</Hash>
</Codenesium>*/