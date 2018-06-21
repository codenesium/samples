using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class ClientRepository : AbstractClientRepository, IClientRepository
        {
                public ClientRepository(
                        ILogger<ClientRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e3b8b8ccca7eb9639a5b2c37168ac57f</Hash>
</Codenesium>*/