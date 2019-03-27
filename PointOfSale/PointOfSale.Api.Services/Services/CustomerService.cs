using MediatR;
using Microsoft.Extensions.Logging;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;

namespace PointOfSaleNS.Api.Services
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
    <Hash>3385f524d7a9333c5865ee067399c4bf</Hash>
</Codenesium>*/