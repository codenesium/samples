using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class ClientCommunicationRepository: AbstractClientCommunicationRepository, IClientCommunicationRepository
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
    <Hash>bdde5825df7b30b57a69afd0b0aee6c8</Hash>
</Codenesium>*/