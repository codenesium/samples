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
                        IDALClientMapper dalclientMapper)
                        : base(logger,
                               clientRepository,
                               clientModelValidator,
                               bolclientMapper,
                               dalclientMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>3f5a16c8d98021d82f8dfde825748d8f</Hash>
</Codenesium>*/