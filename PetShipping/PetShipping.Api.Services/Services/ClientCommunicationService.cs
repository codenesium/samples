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
			IBOLClientCommunicationMapper BOLclientCommunicationMapper,
			IDALClientCommunicationMapper DALclientCommunicationMapper)
			: base(logger, clientCommunicationRepository,
			       clientCommunicationModelValidator,
			       BOLclientCommunicationMapper,
			       DALclientCommunicationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>6ec5d6fbcabc08d53285d1f166a7a221</Hash>
</Codenesium>*/