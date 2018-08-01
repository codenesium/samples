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
	public partial class ClientCommunicationService : AbstractClientCommunicationService, IClientCommunicationService
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
    <Hash>8726266a980f1e56f791b1c00e994a76</Hash>
</Codenesium>*/