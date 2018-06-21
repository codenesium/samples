using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
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
    <Hash>76a08890b492591ff626e6e6d44e92e4</Hash>
</Codenesium>*/