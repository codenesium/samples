using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesReasonService : AbstractSalesReasonService, ISalesReasonService
	{
		public SalesReasonService(
			ILogger<ISalesReasonRepository> logger,
			IMediator mediator,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonServerRequestModelValidator salesReasonModelValidator,
			IDALSalesReasonMapper dalSalesReasonMapper)
			: base(logger,
			       mediator,
			       salesReasonRepository,
			       salesReasonModelValidator,
			       dalSalesReasonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1f1802a755e694a635532db1c5d9af79</Hash>
</Codenesium>*/