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
			IClientCommunicationModelValidator clientCommunicationModelValidator)
			: base(logger, clientCommunicationRepository, clientCommunicationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>14e429bf6bf5aa91729076083bd29ef9</Hash>
</Codenesium>*/