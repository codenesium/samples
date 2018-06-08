using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class BusinessEntityRepository: AbstractBusinessEntityRepository, IBusinessEntityRepository
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
    <Hash>1376061720c21bd2fc57a68295a8d6cc</Hash>
</Codenesium>*/