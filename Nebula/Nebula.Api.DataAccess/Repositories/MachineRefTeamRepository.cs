using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class MachineRefTeamRepository : AbstractMachineRefTeamRepository, IMachineRefTeamRepository
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
    <Hash>c85b6bb192e0c6eac16ab9f694eebf4c</Hash>
</Codenesium>*/