using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ShiftService : AbstractShiftService, IShiftService
	{
		public ShiftService(
			ILogger<IShiftRepository> logger,
			IMediator mediator,
			IShiftRepository shiftRepository,
			IApiShiftServerRequestModelValidator shiftModelValidator,
			IDALShiftMapper dalShiftMapper)
			: base(logger,
			       mediator,
			       shiftRepository,
			       shiftModelValidator,
			       dalShiftMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>14a985a91e275497ca430d29a227feb1</Hash>
</Codenesium>*/