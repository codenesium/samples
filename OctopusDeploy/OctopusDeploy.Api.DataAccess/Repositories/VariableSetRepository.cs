using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class VariableSetRepository : AbstractVariableSetRepository, IVariableSetRepository
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
    <Hash>f133c6a43849fb7b9d775ca510c8b594</Hash>
</Codenesium>*/