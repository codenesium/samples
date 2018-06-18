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
        public class MachineService: AbstractMachineService, IMachineService
        {
                public MachineService(
                        ILogger<IMachineRepository> logger,
                        IMachineRepository machineRepository,
                        IApiMachineRequestModelValidator machineModelValidator,
                        IBOLMachineMapper bolmachineMapper,
                        IDALMachineMapper dalmachineMapper

                        )
                        : base(logger,
                               machineRepository,
                               machineModelValidator,
                               bolmachineMapper,
                               dalmachineMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>69745c9f025c52b892ed7c6873e12885</Hash>
</Codenesium>*/