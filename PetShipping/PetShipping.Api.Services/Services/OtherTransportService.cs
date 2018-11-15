using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class OtherTransportService : AbstractOtherTransportService, IOtherTransportService
	{
		public OtherTransportService(
			ILogger<IOtherTransportRepository> logger,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportServerRequestModelValidator otherTransportModelValidator,
			IBOLOtherTransportMapper bolOtherTransportMapper,
			IDALOtherTransportMapper dalOtherTransportMapper)
			: base(logger,
			       otherTransportRepository,
			       otherTransportModelValidator,
			       bolOtherTransportMapper,
			       dalOtherTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a0a75dc305b3c5b0754eb0ef3f30c41b</Hash>
</Codenesium>*/