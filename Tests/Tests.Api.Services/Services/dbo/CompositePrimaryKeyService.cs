using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class CompositePrimaryKeyService : AbstractCompositePrimaryKeyService, ICompositePrimaryKeyService
	{
		public CompositePrimaryKeyService(
			ILogger<ICompositePrimaryKeyRepository> logger,
			ICompositePrimaryKeyRepository compositePrimaryKeyRepository,
			IApiCompositePrimaryKeyServerRequestModelValidator compositePrimaryKeyModelValidator,
			IBOLCompositePrimaryKeyMapper bolCompositePrimaryKeyMapper,
			IDALCompositePrimaryKeyMapper dalCompositePrimaryKeyMapper)
			: base(logger,
			       compositePrimaryKeyRepository,
			       compositePrimaryKeyModelValidator,
			       bolCompositePrimaryKeyMapper,
			       dalCompositePrimaryKeyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ac2723d51871d1b6aabaa41073210136</Hash>
</Codenesium>*/