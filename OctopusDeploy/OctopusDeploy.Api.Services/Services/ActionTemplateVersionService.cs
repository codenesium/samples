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
        public partial class ActionTemplateVersionService : AbstractActionTemplateVersionService, IActionTemplateVersionService
        {
                public ActionTemplateVersionService(
                        ILogger<IActionTemplateVersionRepository> logger,
                        IActionTemplateVersionRepository actionTemplateVersionRepository,
                        IApiActionTemplateVersionRequestModelValidator actionTemplateVersionModelValidator,
                        IBOLActionTemplateVersionMapper bolactionTemplateVersionMapper,
                        IDALActionTemplateVersionMapper dalactionTemplateVersionMapper
                        )
                        : base(logger,
                               actionTemplateVersionRepository,
                               actionTemplateVersionModelValidator,
                               bolactionTemplateVersionMapper,
                               dalactionTemplateVersionMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d028ca2582d12e2c2fd0c52b60a0e642</Hash>
</Codenesium>*/