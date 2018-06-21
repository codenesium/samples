using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class MachineRepository : AbstractMachineRepository, IMachineRepository
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
    <Hash>6a4fb181eb55f66b7ec5f8a24162864e</Hash>
</Codenesium>*/