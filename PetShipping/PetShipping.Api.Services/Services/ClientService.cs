using Codenesium.DataConversionExtensions.AspNetCore;
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
        public class ClientService : AbstractClientService, IClientService
        {
                public ClientService(
                        ILogger<IClientRepository> logger,
                        IClientRepository clientRepository,
                        IApiClientRequestModelValidator clientModelValidator,
                        IBOLClientMapper bolclientMapper,
                        IDALClientMapper dalclientMapper,
                        IBOLClientCommunicationMapper bolClientCommunicationMapper,
                        IDALClientCommunicationMapper dalClientCommunicationMapper,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper
                        )
                        : base(logger,
                               clientRepository,
                               clientModelValidator,
                               bolclientMapper,
                               dalclientMapper,
                               bolClientCommunicationMapper,
                               dalClientCommunicationMapper,
                               bolPetMapper,
                               dalPetMapper,
                               bolSaleMapper,
                               dalSaleMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>3fa62abc3e9ba33893853c0f725bbcf1</Hash>
</Codenesium>*/