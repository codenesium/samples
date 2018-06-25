using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class IllustrationRepository : AbstractIllustrationRepository, IIllustrationRepository
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
    <Hash>7fd6b79f129841de97e0c806c9a5b2c3</Hash>
</Codenesium>*/