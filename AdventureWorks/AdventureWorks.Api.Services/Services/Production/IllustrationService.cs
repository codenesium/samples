using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class IllustrationService : AbstractIllustrationService, IIllustrationService
	{
		public IllustrationService(
			ILogger<IIllustrationRepository> logger,
			IMediator mediator,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationServerRequestModelValidator illustrationModelValidator,
			IBOLIllustrationMapper bolIllustrationMapper,
			IDALIllustrationMapper dalIllustrationMapper)
			: base(logger,
			       mediator,
			       illustrationRepository,
			       illustrationModelValidator,
			       bolIllustrationMapper,
			       dalIllustrationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>42c59d5c264e95b9f38940404ab4c9fc</Hash>
</Codenesium>*/