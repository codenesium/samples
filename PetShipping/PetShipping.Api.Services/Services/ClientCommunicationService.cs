using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ClientCommunicationService: AbstractClientCommunicationService, IClientCommunicationService
        {
                public ClientCommunicationService(
                        ILogger<ClientCommunicationRepository> logger,
                        IClientCommunicationRepository clientCommunicationRepository,
                        IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator,
                        IBOLClientCommunicationMapper bolclientCommunicationMapper,
                        IDALClientCommunicationMapper dalclientCommunicationMapper

                        )
                        : base(logger,
                               clientCommunicationRepository,
                               clientCommunicationModelValidator,
                               bolclientCommunicationMapper,
                               dalclientCommunicationMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>171bc1b4014178381f363eb676c964c8</Hash>
</Codenesium>*/