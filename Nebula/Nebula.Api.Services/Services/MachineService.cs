using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
        public class MachineService : AbstractMachineService, IMachineService
        {
                public MachineService(
                        ILogger<IMachineRepository> logger,
                        IMachineRepository machineRepository,
                        IApiMachineRequestModelValidator machineModelValidator,
                        IBOLMachineMapper bolmachineMapper,
                        IDALMachineMapper dalmachineMapper,
                        IBOLLinkMapper bolLinkMapper,
                        IDALLinkMapper dalLinkMapper,
                        IBOLMachineRefTeamMapper bolMachineRefTeamMapper,
                        IDALMachineRefTeamMapper dalMachineRefTeamMapper
                        )
                        : base(logger,
                               machineRepository,
                               machineModelValidator,
                               bolmachineMapper,
                               dalmachineMapper,
                               bolLinkMapper,
                               dalLinkMapper,
                               bolMachineRefTeamMapper,
                               dalMachineRefTeamMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>38502ef9a56242bbf71d0e2d5087157d</Hash>
</Codenesium>*/