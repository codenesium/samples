using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesPersonService : AbstractSalesPersonService, ISalesPersonService
	{
		public SalesPersonService(
			ILogger<ISalesPersonRepository> logger,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonServerRequestModelValidator salesPersonModelValidator,
			IBOLSalesPersonMapper bolSalesPersonMapper,
			IDALSalesPersonMapper dalSalesPersonMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IBOLStoreMapper bolStoreMapper,
			IDALStoreMapper dalStoreMapper)
			: base(logger,
			       salesPersonRepository,
			       salesPersonModelValidator,
			       bolSalesPersonMapper,
			       dalSalesPersonMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper,
			       bolStoreMapper,
			       dalStoreMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>33f4b51bd2e9cb0909cdadc569835c68</Hash>
</Codenesium>*/