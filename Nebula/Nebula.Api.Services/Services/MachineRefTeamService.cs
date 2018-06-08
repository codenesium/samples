using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class MachineRefTeamService: AbstractMachineRefTeamService, IMachineRefTeamService
        {
                public MachineRefTeamService(
                        ILogger<MachineRefTeamRepository> logger,
                        IMachineRefTeamRepository machineRefTeamRepository,
                        IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator,
                        IBOLMachineRefTeamMapper bolmachineRefTeamMapper,
                        IDALMachineRefTeamMapper dalmachineRefTeamMapper)
                        : base(logger,
                               machineRefTeamRepository,
                               machineRefTeamModelValidator,
                               bolmachineRefTeamMapper,
                               dalmachineRefTeamMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>33484fb545c267b322840d220dc4299b</Hash>
</Codenesium>*/