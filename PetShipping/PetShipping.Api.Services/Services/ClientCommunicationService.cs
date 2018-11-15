using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class ClientCommunicationService : AbstractClientCommunicationService, IClientCommunicationService
	{
		public ClientCommunicationService(
			ILogger<IClientCommunicationRepository> logger,
			IClientCommunicationRepository clientCommunicationRepository,
			IApiClientCommunicationServerRequestModelValidator clientCommunicationModelValidator,
			IBOLClientCommunicationMapper bolClientCommunicationMapper,
			IDALClientCommunicationMapper dalClientCommunicationMapper)
			: base(logger,
			       clientCommunicationRepository,
			       clientCommunicationModelValidator,
			       bolClientCommunicationMapper,
			       dalClientCommunicationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>42bb3e5faac407b20b4d47e6b3f52f36</Hash>
</Codenesium>*/