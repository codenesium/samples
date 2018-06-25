using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ScrapReasonRepository : AbstractScrapReasonRepository, IScrapReasonRepository
        {
                public ScrapReasonRepository(
                        ILogger<ScrapReasonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ecfd295029a146f45c65f966c1ed384f</Hash>
</Codenesium>*/