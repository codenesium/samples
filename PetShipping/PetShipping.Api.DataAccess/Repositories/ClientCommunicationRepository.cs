using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class ClientCommunicationRepository : AbstractClientCommunicationRepository, IClientCommunicationRepository
        {
                public ClientCommunicationRepository(
                        ILogger<ClientCommunicationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7337500de7a8319384deebbdd92bf6d8</Hash>
</Codenesium>*/