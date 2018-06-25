using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class BusinessEntityRepository : AbstractBusinessEntityRepository, IBusinessEntityRepository
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
    <Hash>7a057567c9f1ee2c216a756365c930ff</Hash>
</Codenesium>*/