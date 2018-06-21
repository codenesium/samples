using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class BusinessEntityRepository : AbstractBusinessEntityRepository, IBusinessEntityRepository
        {
                public BusinessEntityRepository(
                        ILogger<BusinessEntityRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ce5c04bc79acebd27c10c215f15f6f92</Hash>
</Codenesium>*/