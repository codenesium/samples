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
			IBOLClientMapper BOLclientMapper,
			IDALClientMapper DALclientMapper)
			: base(logger, clientRepository,
			       clientModelValidator,
			       BOLclientMapper,
			       DALclientMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>5fa60ab9b5d93657a0dde0d58a2b5a4a</Hash>
</Codenesium>*/