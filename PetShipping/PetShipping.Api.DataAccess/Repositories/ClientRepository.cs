using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>cb9e54479049499b577ffbcbf98f00b4</Hash>
</Codenesium>*/