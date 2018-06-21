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
        public class VariableSetService : AbstractVariableSetService, IVariableSetService
        {
                public VariableSetService(
                        ILogger<IVariableSetRepository> logger,
                        IVariableSetRepository variableSetRepository,
                        IApiVariableSetRequestModelValidator variableSetModelValidator,
                        IBOLVariableSetMapper bolvariableSetMapper,
                        IDALVariableSetMapper dalvariableSetMapper
                        )
                        : base(logger,
                               variableSetRepository,
                               variableSetModelValidator,
                               bolvariableSetMapper,
                               dalvariableSetMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>97fed245149bb65fc45b7764e1c77df2</Hash>
</Codenesium>*/