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
        public class VariableSetService: AbstractVariableSetService, IVariableSetService
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
                               dalvariableSetMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e15cb51e244ecd9714722217d75cb261</Hash>
</Codenesium>*/