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
			IDALVPersonMapper dalVPersonMapper)
			: base(logger,
			       mediator,
			       vPersonRepository,
			       vPersonModelValidator,
			       dalVPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a176499a26941c4aabcaf0c010f164dc</Hash>
</Codenesium>*/