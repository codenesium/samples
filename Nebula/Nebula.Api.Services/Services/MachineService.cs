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
                        ILogger<IMachineRepository> logger,
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
    <Hash>f7e683a6844f223c02b25b09d45ea7a0</Hash>
</Codenesium>*/