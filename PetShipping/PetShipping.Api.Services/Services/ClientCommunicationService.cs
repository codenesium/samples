using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial class ClientCommunicationService : AbstractClientCommunicationService, IClientCommunicationService
	{
		public ClientCommunicationService(
			ILogger<IClientCommunicationRepository> logger,
			IClientCommunicationRepository clientCommunicationRepository,
			IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator,
			IBOLClientCommunicationMapper bolclientCommunicationMapper,
			IDALClientCommunicationMapper dalclientCommunicationMapper)
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
    <Hash>7e911874ae78f808ba0a904b4d97c19f</Hash>
</Codenesium>*/