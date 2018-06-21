using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class IllustrationRepository : AbstractIllustrationRepository, IIllustrationRepository
        {
                public IllustrationRepository(
                        ILogger<IllustrationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>283146602b4440a96ba5b5d7d3b1fbb4</Hash>
</Codenesium>*/