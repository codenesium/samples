using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class IllustrationRepository: AbstractIllustrationRepository, IIllustrationRepository
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
    <Hash>f8f9b1f92bbd962114d24aaa3a11e175</Hash>
</Codenesium>*/