using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class OtherTransportService : AbstractOtherTransportService, IOtherTransportService
	{
		public OtherTransportService(
			ILogger<IOtherTransportRepository> logger,
			IMediator mediator,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportServerRequestModelValidator otherTransportModelValidator,
			IBOLOtherTransportMapper bolOtherTransportMapper,
			IDALOtherTransportMapper dalOtherTransportMapper)
			: base(logger,
			       mediator,
			       otherTransportRepository,
			       otherTransportModelValidator,
			       bolOtherTransportMapper,
			       dalOtherTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d46b6f4c10e639a9332e9ff318b97bc6</Hash>
</Codenesium>*/