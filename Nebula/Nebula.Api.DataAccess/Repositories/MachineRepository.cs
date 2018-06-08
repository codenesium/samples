using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class MachineRepository: AbstractMachineRepository, IMachineRepository
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
    <Hash>fab7370d58b3a1183818a7887452c470</Hash>
</Codenesium>*/