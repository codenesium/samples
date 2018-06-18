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
                        ILogger<IMachineRefTeamRepository> logger,
                        IMachineRefTeamRepository machineRefTeamRepository,
                        IApiMachineRefTeamRequestModelValidator machineRefTeamModelValidator,
                        IBOLMachineRefTeamMapper bolmachineRefTeamMapper,
                        IDALMachineRefTeamMapper dalmachineRefTeamMapper

                        )
                        : base(logger,
                               machineRefTeamRepository,
                               machineRefTeamModelValidator,
                               bolmachineRefTeamMapper,
                               dalmachineRefTeamMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>ce3c5ac47551120fef7532d4713a504b</Hash>
</Codenesium>*/