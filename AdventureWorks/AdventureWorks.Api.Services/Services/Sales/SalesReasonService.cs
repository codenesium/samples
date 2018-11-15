using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesReasonService : AbstractSalesReasonService, ISalesReasonService
	{
		public SalesReasonService(
			ILogger<ISalesReasonRepository> logger,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonServerRequestModelValidator salesReasonModelValidator,
			IBOLSalesReasonMapper bolSalesReasonMapper,
			IDALSalesReasonMapper dalSalesReasonMapper)
			: base(logger,
			       salesReasonRepository,
			       salesReasonModelValidator,
			       bolSalesReasonMapper,
			       dalSalesReasonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9ef04a344cb26dcbeff8104b5096a4bf</Hash>
</Codenesium>*/