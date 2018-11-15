using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class CustomerService : AbstractCustomerService, ICustomerService
	{
		public CustomerService(
			ILogger<ICustomerRepository> logger,
			ICustomerRepository customerRepository,
			IApiCustomerServerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base(logger,
			       customerRepository,
			       customerModelValidator,
			       bolCustomerMapper,
			       dalCustomerMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>33e96c9c46cc9a2d887145b351e55d55</Hash>
</Codenesium>*/