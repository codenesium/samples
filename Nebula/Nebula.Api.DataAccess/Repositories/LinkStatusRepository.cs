using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class LinkStatusRepository : AbstractLinkStatusRepository, ILinkStatusRepository
        {
                public LinkStatusRepository(
                        ILogger<LinkStatusRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>78104fd36b7f98a21c8165e1ced75ed5</Hash>
</Codenesium>*/