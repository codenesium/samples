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
    <Hash>6f2024cda4ab7a58715ab8955cca7457</Hash>
</Codenesium>*/