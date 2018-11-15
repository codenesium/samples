using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class PersonRefService : AbstractPersonRefService, IPersonRefService
	{
		public PersonRefService(
			ILogger<IPersonRefRepository> logger,
			IPersonRefRepository personRefRepository,
			IApiPersonRefServerRequestModelValidator personRefModelValidator,
			IBOLPersonRefMapper bolPersonRefMapper,
			IDALPersonRefMapper dalPersonRefMapper)
			: base(logger,
			       personRefRepository,
			       personRefModelValidator,
			       bolPersonRefMapper,
			       dalPersonRefMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bdc12d21e74e1274779c2d0438f036d7</Hash>
</Codenesium>*/