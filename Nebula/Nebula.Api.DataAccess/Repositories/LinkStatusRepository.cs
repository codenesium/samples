using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class LinkStatusRepository: AbstractLinkStatusRepository, ILinkStatusRepository
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
    <Hash>603fb7c4123b985b3b70aa1142f3bfbf</Hash>
</Codenesium>*/