using Codenesium.DataConversionExtensions;
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
    <Hash>1b1dc7c714832aa260f09600d818a534</Hash>
</Codenesium>*/