using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class HandlerRepository: AbstractHandlerRepository, IHandlerRepository
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
    <Hash>a97506500ea0e30398c704a2b3c9c917</Hash>
</Codenesium>*/