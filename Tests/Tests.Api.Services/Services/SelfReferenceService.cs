using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class SelfReferenceService : AbstractSelfReferenceService, ISelfReferenceService
	{
		public SelfReferenceService(
			ILogger<ISelfReferenceRepository> logger,
			IMediator mediator,
			ISelfReferenceRepository selfReferenceRepository,
			IApiSelfReferenceServerRequestModelValidator selfReferenceModelValidator,
			IBOLSelfReferenceMapper bolSelfReferenceMapper,
			IDALSelfReferenceMapper dalSelfReferenceMapper)
			: base(logger,
			       mediator,
			       selfReferenceRepository,
			       selfReferenceModelValidator,
			       bolSelfReferenceMapper,
			       dalSelfReferenceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7c9e1460631d10f7145d3a2580f828a0</Hash>
</Codenesium>*/