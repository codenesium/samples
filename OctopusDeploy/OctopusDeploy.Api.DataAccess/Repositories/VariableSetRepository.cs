using Codenesium.DataConversionExtensions;
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
    <Hash>8e89849ce3e83cfd24a280d4213a4df3</Hash>
</Codenesium>*/