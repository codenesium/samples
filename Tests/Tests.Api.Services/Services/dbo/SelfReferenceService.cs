using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class SelfReferenceService : AbstractSelfReferenceService, ISelfReferenceService
	{
		public SelfReferenceService(
			ILogger<ISelfReferenceRepository> logger,
			ISelfReferenceRepository selfReferenceRepository,
			IApiSelfReferenceServerRequestModelValidator selfReferenceModelValidator,
			IBOLSelfReferenceMapper bolSelfReferenceMapper,
			IDALSelfReferenceMapper dalSelfReferenceMapper)
			: base(logger,
			       selfReferenceRepository,
			       selfReferenceModelValidator,
			       bolSelfReferenceMapper,
			       dalSelfReferenceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c0b7edaab072fbfca90ae06883b65abf</Hash>
</Codenesium>*/