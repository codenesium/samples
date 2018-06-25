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
        public partial class MachineRefTeamService : AbstractMachineRefTeamService, IMachineRefTeamService
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
    <Hash>5d5e8c893f845bc5a9d712b2ff124f94</Hash>
</Codenesium>*/