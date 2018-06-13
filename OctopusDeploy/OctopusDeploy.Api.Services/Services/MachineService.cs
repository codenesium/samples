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
                        ILogger<MachineRepository> logger,
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
    <Hash>9b8607223160c3fad4cc9dbc4737323b</Hash>
</Codenesium>*/