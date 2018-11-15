using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class CustomerService : AbstractCustomerService, ICustomerService
	{
		public CustomerService(
			ILogger<ICustomerRepository> logger,
			ICustomerRepository customerRepository,
			IApiCustomerServerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper,
			IBOLCustomerCommunicationMapper bolCustomerCommunicationMapper,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper)
			: base(logger,
			       customerRepository,
			       customerModelValidator,
			       bolCustomerMapper,
			       dalCustomerMapper,
			       bolCustomerCommunicationMapper,
			       dalCustomerCommunicationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ec48b73ebec350ae423563826bc21fc5</Hash>
</Codenesium>*/