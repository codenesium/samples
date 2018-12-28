using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class PersonRefService : AbstractPersonRefService, IPersonRefService
	{
		public PersonRefService(
			ILogger<IPersonRefRepository> logger,
			IMediator mediator,
			IPersonRefRepository personRefRepository,
			IApiPersonRefServerRequestModelValidator personRefModelValidator,
			IBOLPersonRefMapper bolPersonRefMapper,
			IDALPersonRefMapper dalPersonRefMapper)
			: base(logger,
			       mediator,
			       personRefRepository,
			       personRefModelValidator,
			       bolPersonRefMapper,
			       dalPersonRefMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8c95d230c90d801fd1d45d56b471d0fb</Hash>
</Codenesium>*/