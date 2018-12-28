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
			IBOLSalesReasonMapper bolSalesReasonMapper,
			IDALSalesReasonMapper dalSalesReasonMapper)
			: base(logger,
			       mediator,
			       salesReasonRepository,
			       salesReasonModelValidator,
			       bolSalesReasonMapper,
			       dalSalesReasonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3e0a907340d53cd358bcf26255a8d9f8</Hash>
</Codenesium>*/