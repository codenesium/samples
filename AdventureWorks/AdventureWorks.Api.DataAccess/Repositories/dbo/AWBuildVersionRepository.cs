using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class AWBuildVersionRepository: AbstractAWBuildVersionRepository, IAWBuildVersionRepository
        {
                public AWBuildVersionRepository(
                        ILogger<AWBuildVersionRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>27cc95da460ec431263f148157134869</Hash>
</Codenesium>*/