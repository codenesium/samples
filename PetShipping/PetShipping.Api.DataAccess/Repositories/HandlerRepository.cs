using Codenesium.DataConversionExtensions;
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
    <Hash>c1ee1cc5c2a272515029df4604912dfa</Hash>
</Codenesium>*/