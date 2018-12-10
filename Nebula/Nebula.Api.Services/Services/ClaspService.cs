using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class ClaspService : AbstractClaspService, IClaspService
	{
		public ClaspService(
			ILogger<IClaspRepository> logger,
			IClaspRepository claspRepository,
			IApiClaspServerRequestModelValidator claspModelValidator,
			IBOLClaspMapper bolClaspMapper,
			IDALClaspMapper dalClaspMapper)
			: base(logger,
			       claspRepository,
			       claspModelValidator,
			       bolClaspMapper,
			       dalClaspMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c9aecfd618bafe06fd82e3f37a66c666</Hash>
</Codenesium>*/