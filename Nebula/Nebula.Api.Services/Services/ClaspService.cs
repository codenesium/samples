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
			IDALClaspMapper dalClaspMapper)
			: base(logger,
			       mediator,
			       claspRepository,
			       claspModelValidator,
			       dalClaspMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>29190b163dd23086656f1975b846ef92</Hash>
</Codenesium>*/