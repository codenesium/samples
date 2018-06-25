using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public partial class MachineRepository : AbstractMachineRepository, IMachineRepository
        {
                public MachineRepository(
                        ILogger<MachineRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d02c79b1ca9f3a648170a83d358510ff</Hash>
</Codenesium>*/