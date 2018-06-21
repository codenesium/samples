using Codenesium.DataConversionExtensions;
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
    <Hash>4acb64f218a2d7cf4d66ecc3478d4282</Hash>
</Codenesium>*/