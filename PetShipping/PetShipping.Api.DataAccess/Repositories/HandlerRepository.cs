using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class HandlerRepository : AbstractHandlerRepository, IHandlerRepository
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
    <Hash>3c83e2c431edaf0be4fb48f3f8264dac</Hash>
</Codenesium>*/