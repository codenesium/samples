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
        public class ClientService: AbstractClientService, IClientService
        {
                public ClientService(
                        ILogger<ClientRepository> logger,
                        IClientRepository clientRepository,
                        IApiClientRequestModelValidator clientModelValidator,
                        IBOLClientMapper bolclientMapper,
                        IDALClientMapper dalclientMapper
                        ,
                        IBOLClientCommunicationMapper bolClientCommunicationMapper,
                        IDALClientCommunicationMapper dalClientCommunicationMapper
                        ,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper
                        ,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper

                        )
                        : base(logger,
                               clientRepository,
                               clientModelValidator,
                               bolclientMapper,
                               dalclientMapper
                               ,
                               bolClientCommunicationMapper,
                               dalClientCommunicationMapper
                               ,
                               bolPetMapper,
                               dalPetMapper
                               ,
                               bolSaleMapper,
                               dalSaleMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>8219d795881c6e4fb52de98f0e3e1ba1</Hash>
</Codenesium>*/