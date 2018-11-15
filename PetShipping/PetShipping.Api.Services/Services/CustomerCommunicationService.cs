using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class CustomerCommunicationService : AbstractCustomerCommunicationService, ICustomerCommunicationService
	{
		public CustomerCommunicationService(
			ILogger<ICustomerCommunicationRepository> logger,
			ICustomerCommunicationRepository customerCommunicationRepository,
			IApiCustomerCommunicationServerRequestModelValidator customerCommunicationModelValidator,
			IBOLCustomerCommunicationMapper bolCustomerCommunicationMapper,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper)
			: base(logger,
			       customerCommunicationRepository,
			       customerCommunicationModelValidator,
			       bolCustomerCommunicationMapper,
			       dalCustomerCommunicationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0fcb3d64f47197532af062a949bab05c</Hash>
</Codenesium>*/