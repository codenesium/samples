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
			IApiClientCommunicationModelValidator clientCommunicationModelValidator)
			: base(logger, clientCommunicationRepository, clientCommunicationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>00daecc1afb60285937f1a7a5e426af4</Hash>
</Codenesium>*/