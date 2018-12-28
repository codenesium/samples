using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class ClaspService : AbstractClaspService, IClaspService
	{
		public ClaspService(
			ILogger<IClaspRepository> logger,
			IMediator mediator,
			IClaspRepository claspRepository,
			IApiClaspServerRequestModelValidator claspModelValidator,
			IBOLClaspMapper bolClaspMapper,
			IDALClaspMapper dalClaspMapper)
			: base(logger,
			       mediator,
			       claspRepository,
			       claspModelValidator,
			       bolClaspMapper,
			       dalClaspMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>401ffb9ef4fdf5788a1f6320ff66e576</Hash>
</Codenesium>*/