using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class CustomerService : AbstractCustomerService, ICustomerService
	{
		public CustomerService(
			ILogger<ICustomerRepository> logger,
			IMediator mediator,
			ICustomerRepository customerRepository,
			IApiCustomerServerRequestModelValidator customerModelValidator,
			IDALCustomerMapper dalCustomerMapper)
			: base(logger,
			       mediator,
			       customerRepository,
			       customerModelValidator,
			       dalCustomerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4905be25ee83f30dd8293798968260d3</Hash>
</Codenesium>*/