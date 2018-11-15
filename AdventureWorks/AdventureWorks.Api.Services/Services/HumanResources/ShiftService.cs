using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ShiftService : AbstractShiftService, IShiftService
	{
		public ShiftService(
			ILogger<IShiftRepository> logger,
			IShiftRepository shiftRepository,
			IApiShiftServerRequestModelValidator shiftModelValidator,
			IBOLShiftMapper bolShiftMapper,
			IDALShiftMapper dalShiftMapper)
			: base(logger,
			       shiftRepository,
			       shiftModelValidator,
			       bolShiftMapper,
			       dalShiftMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>10263f848ba91e05060a73501d4b2760</Hash>
</Codenesium>*/