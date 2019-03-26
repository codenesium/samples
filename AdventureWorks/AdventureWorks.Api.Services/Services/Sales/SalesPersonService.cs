using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesPersonService : AbstractSalesPersonService, ISalesPersonService
	{
		public SalesPersonService(
			ILogger<ISalesPersonRepository> logger,
			IMediator mediator,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonServerRequestModelValidator salesPersonModelValidator,
			IDALSalesPersonMapper dalSalesPersonMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IDALStoreMapper dalStoreMapper)
			: base(logger,
			       mediator,
			       salesPersonRepository,
			       salesPersonModelValidator,
			       dalSalesPersonMapper,
			       dalSalesOrderHeaderMapper,
			       dalStoreMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>aac1a0a1a91bdff47f2b5f1828809c13</Hash>
</Codenesium>*/