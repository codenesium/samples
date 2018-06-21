using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class HandlerRepository : AbstractHandlerRepository, IHandlerRepository
        {
                public HandlerRepository(
                        ILogger<HandlerRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>3be3644ed42dcd7f61c3c549aaef2361</Hash>
</Codenesium>*/