using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class CustomerCommunicationService : AbstractCustomerCommunicationService, ICustomerCommunicationService
	{
		public CustomerCommunicationService(
			ILogger<ICustomerCommunicationRepository> logger,
			IMediator mediator,
			ICustomerCommunicationRepository customerCommunicationRepository,
			IApiCustomerCommunicationServerRequestModelValidator customerCommunicationModelValidator,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper)
			: base(logger,
			       mediator,
			       customerCommunicationRepository,
			       customerCommunicationModelValidator,
			       dalCustomerCommunicationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d0e3ab5fdb367da457ba5cf5e3b0ddc4</Hash>
</Codenesium>*/