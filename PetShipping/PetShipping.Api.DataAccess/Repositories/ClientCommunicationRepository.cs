using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class ClientCommunicationRepository : AbstractClientCommunicationRepository, IClientCommunicationRepository
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
    <Hash>4e94bc42378801a229424c0192276cc4</Hash>
</Codenesium>*/