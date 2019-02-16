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
			IDALIllustrationMapper dalIllustrationMapper)
			: base(logger,
			       mediator,
			       illustrationRepository,
			       illustrationModelValidator,
			       dalIllustrationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9563b82d57d39c57b3fac5bcb90e9849</Hash>
</Codenesium>*/