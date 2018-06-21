using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class LinkTypesRepository : AbstractLinkTypesRepository, ILinkTypesRepository
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
    <Hash>23f45ae696e66591122860be7b4b20f5</Hash>
</Codenesium>*/