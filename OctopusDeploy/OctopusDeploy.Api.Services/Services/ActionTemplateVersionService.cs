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
        public class ActionTemplateVersionService : AbstractActionTemplateVersionService, IActionTemplateVersionService
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
    <Hash>4b4fec3522239bd48ad5c170e10a56e2</Hash>
</Codenesium>*/