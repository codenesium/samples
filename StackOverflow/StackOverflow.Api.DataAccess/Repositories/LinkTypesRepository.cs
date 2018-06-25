using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class LinkTypesRepository : AbstractLinkTypesRepository, ILinkTypesRepository
        {
                public LinkTypesRepository(
                        ILogger<LinkTypesRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>122d4c07e95dda042dd2bc1acaad66c3</Hash>
</Codenesium>*/