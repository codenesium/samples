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
			IDALOtherTransportMapper dalOtherTransportMapper)
			: base(logger,
			       mediator,
			       otherTransportRepository,
			       otherTransportModelValidator,
			       dalOtherTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ce8a68ecea84d022f609e66d384f5857</Hash>
</Codenesium>*/