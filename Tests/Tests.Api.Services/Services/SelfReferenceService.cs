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
			IDALSelfReferenceMapper dalSelfReferenceMapper)
			: base(logger,
			       mediator,
			       selfReferenceRepository,
			       selfReferenceModelValidator,
			       dalSelfReferenceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ef29f69d3f1a80e897300e8ce5036a5f</Hash>
</Codenesium>*/