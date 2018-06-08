using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class MachineRefTeamRepository: AbstractMachineRefTeamRepository, IMachineRefTeamRepository
        {
                public MachineRefTeamRepository(
                        ILogger<MachineRefTeamRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2ac5a5cdd277b7f42503557e65727c04</Hash>
</Codenesium>*/