using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CultureRepository: AbstractCultureRepository, ICultureRepository
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
    <Hash>0512921da3f7c4a01e2fcfda9f6c3727</Hash>
</Codenesium>*/