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
        public partial class VariableSetService : AbstractVariableSetService, IVariableSetService
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
    <Hash>609c536a983ceda5ef393db29df773bf</Hash>
</Codenesium>*/