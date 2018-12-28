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
			IBOLCustomerCommunicationMapper bolCustomerCommunicationMapper,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper)
			: base(logger,
			       mediator,
			       customerCommunicationRepository,
			       customerCommunicationModelValidator,
			       bolCustomerCommunicationMapper,
			       dalCustomerCommunicationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f6b3d657d037ea272f8c135b63b952ab</Hash>
</Codenesium>*/