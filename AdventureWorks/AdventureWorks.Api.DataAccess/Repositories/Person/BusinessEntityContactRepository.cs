using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class BusinessEntityContactRepository : AbstractBusinessEntityContactRepository, IBusinessEntityContactRepository
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
    <Hash>799d044d4efb60afdd35f2b2952d9791</Hash>
</Codenesium>*/