using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class BusinessEntityContactRepository : AbstractBusinessEntityContactRepository, IBusinessEntityContactRepository
        {
                public BusinessEntityContactRepository(
                        ILogger<BusinessEntityContactRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>48e5165ffac81c2af80a8f57c683092c</Hash>
</Codenesium>*/