using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class CustomerService : AbstractCustomerService, ICustomerService
	{
		public CustomerService(
			ILogger<ICustomerRepository> logger,
			ICustomerRepository customerRepository,
			IApiCustomerServerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper)
			: base(logger,
			       customerRepository,
			       customerModelValidator,
			       bolCustomerMapper,
			       dalCustomerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>48cbdad8c6397faf93610ee4fe08f81b</Hash>
</Codenesium>*/