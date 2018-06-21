using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class VariableSetRepository : AbstractVariableSetRepository, IVariableSetRepository
        {
                public VariableSetRepository(
                        ILogger<VariableSetRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d21ec2e7a1ead45d3bb7c51e4e6b9d5f</Hash>
</Codenesium>*/