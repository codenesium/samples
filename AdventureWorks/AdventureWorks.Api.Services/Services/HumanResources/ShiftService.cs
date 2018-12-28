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
			IBOLShiftMapper bolShiftMapper,
			IDALShiftMapper dalShiftMapper)
			: base(logger,
			       mediator,
			       shiftRepository,
			       shiftModelValidator,
			       bolShiftMapper,
			       dalShiftMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>206d96899a1571b4da53803189cc6df0</Hash>
</Codenesium>*/