using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
        public class ClientCommunicationService : AbstractClientCommunicationService, IClientCommunicationService
        {
                public ClientCommunicationService(
                        ILogger<IClientCommunicationRepository> logger,
                        IClientCommunicationRepository clientCommunicationRepository,
                        IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator,
                        IBOLClientCommunicationMapper bolclientCommunicationMapper,
                        IDALClientCommunicationMapper dalclientCommunicationMapper
                        )
                        : base(logger,
                               clientCommunicationRepository,
                               clientCommunicationModelValidator,
                               bolclientCommunicationMapper,
                               dalclientCommunicationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>020d53bf9ba3614bcca505ca98c26214</Hash>
</Codenesium>*/