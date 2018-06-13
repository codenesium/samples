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
        public class MachineService: AbstractMachineService, IMachineService
        {
                public MachineService(
                        ILogger<MachineRepository> logger,
                        IMachineRepository machineRepository,
                        IApiMachineRequestModelValidator machineModelValidator,
                        IBOLMachineMapper bolmachineMapper,
                        IDALMachineMapper dalmachineMapper
                        ,
                        IBOLLinkMapper bolLinkMapper,
                        IDALLinkMapper dalLinkMapper
                        ,
                        IBOLMachineRefTeamMapper bolMachineRefTeamMapper,
                        IDALMachineRefTeamMapper dalMachineRefTeamMapper

                        )
                        : base(logger,
                               machineRepository,
                               machineModelValidator,
                               bolmachineMapper,
                               dalmachineMapper
                               ,
                               bolLinkMapper,
                               dalLinkMapper
                               ,
                               bolMachineRefTeamMapper,
                               dalMachineRefTeamMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>8b58242b645984988fbb1db0ad147d0a</Hash>
</Codenesium>*/