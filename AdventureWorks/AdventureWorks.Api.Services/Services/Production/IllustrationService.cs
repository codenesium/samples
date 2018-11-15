using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class IllustrationService : AbstractIllustrationService, IIllustrationService
	{
		public IllustrationService(
			ILogger<IIllustrationRepository> logger,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationServerRequestModelValidator illustrationModelValidator,
			IBOLIllustrationMapper bolIllustrationMapper,
			IDALIllustrationMapper dalIllustrationMapper)
			: base(logger,
			       illustrationRepository,
			       illustrationModelValidator,
			       bolIllustrationMapper,
			       dalIllustrationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3d3bb10a9d76ded1c91f93ec9f4e8d73</Hash>
</Codenesium>*/