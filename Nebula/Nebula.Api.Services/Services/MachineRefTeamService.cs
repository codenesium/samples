using Codenesium.DataConversionExtensions;
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
        public class MachineRefTeamService : AbstractMachineRefTeamService, IMachineRefTeamService
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
                               dalmachineRefTeamMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2b1d510f25f63bf2eb8a6e5d14e8cde4</Hash>
</Codenesium>*/