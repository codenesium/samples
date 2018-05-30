using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOClientCommunication: AbstractBOClientCommunication, IBOClientCommunication
	{
		public BOClientCommunication(
			ILogger<ClientCommunicationRepository> logger,
			IClientCommunicationRepository clientCommunicationRepository,
			IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator,
			IBOLClientCommunicationMapper clientCommunicationMapper)
			: base(logger, clientCommunicationRepository, clientCommunicationModelValidator, clientCommunicationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>48d8380f71a701af6fa28523b776ecca</Hash>
</Codenesium>*/