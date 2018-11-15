using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class ClientService : AbstractClientService, IClientService
	{
		public ClientService(
			ILogger<IClientRepository> logger,
			IClientRepository clientRepository,
			IApiClientServerRequestModelValidator clientModelValidator,
			IBOLClientMapper bolClientMapper,
			IDALClientMapper dalClientMapper,
			IBOLClientCommunicationMapper bolClientCommunicationMapper,
			IDALClientCommunicationMapper dalClientCommunicationMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       clientRepository,
			       clientModelValidator,
			       bolClientMapper,
			       dalClientMapper,
			       bolClientCommunicationMapper,
			       dalClientCommunicationMapper,
			       bolPetMapper,
			       dalPetMapper,
			       bolSaleMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>538a05c569cf02b54ddc97a4b3c5db42</Hash>
</Codenesium>*/