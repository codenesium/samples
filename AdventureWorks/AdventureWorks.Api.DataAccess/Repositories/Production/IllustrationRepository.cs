using Codenesium.DataConversionExtensions;
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
    <Hash>ca7b1abc74581dcbc4c1bc0ba82ca145</Hash>
</Codenesium>*/