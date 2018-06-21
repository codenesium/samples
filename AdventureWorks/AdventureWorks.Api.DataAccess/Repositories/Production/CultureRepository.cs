using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CultureRepository : AbstractCultureRepository, ICultureRepository
        {
                public CultureRepository(
                        ILogger<CultureRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>aad69efea400103a04f107602c46fe14</Hash>
</Codenesium>*/