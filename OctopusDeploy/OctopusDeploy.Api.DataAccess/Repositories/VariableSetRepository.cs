using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class VariableSetRepository: AbstractVariableSetRepository, IVariableSetRepository
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
    <Hash>7280f5ce88e6103953b6edae6588cc4b</Hash>
</Codenesium>*/