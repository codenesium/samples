using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public partial class MachineRefTeamRepository : AbstractMachineRefTeamRepository, IMachineRefTeamRepository
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
    <Hash>d0ac910b661fd3f1789de7b68efc91f5</Hash>
</Codenesium>*/