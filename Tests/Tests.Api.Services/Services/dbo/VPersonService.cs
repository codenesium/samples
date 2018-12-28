using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class VPersonService : AbstractVPersonService, IVPersonService
	{
		public VPersonService(
			ILogger<IVPersonRepository> logger,
			IMediator mediator,
			IVPersonRepository vPersonRepository,
			IApiVPersonServerRequestModelValidator vPersonModelValidator,
			IBOLVPersonMapper bolVPersonMapper,
			IDALVPersonMapper dalVPersonMapper)
			: base(logger,
			       mediator,
			       vPersonRepository,
			       vPersonModelValidator,
			       bolVPersonMapper,
			       dalVPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>228ecac1a61f88238db64b2ad41f8832</Hash>
</Codenesium>*/