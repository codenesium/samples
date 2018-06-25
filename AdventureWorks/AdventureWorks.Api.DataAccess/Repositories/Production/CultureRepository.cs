using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class CultureRepository : AbstractCultureRepository, ICultureRepository
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
    <Hash>88a5234e9dd2ed07ba4b98a30107fcdc</Hash>
</Codenesium>*/