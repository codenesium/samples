using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class PasswordService : AbstractPasswordService, IPasswordService
	{
		public PasswordService(
			ILogger<IPasswordRepository> logger,
			IMediator mediator,
			IPasswordRepository passwordRepository,
			IApiPasswordServerRequestModelValidator passwordModelValidator,
			IBOLPasswordMapper bolPasswordMapper,
			IDALPasswordMapper dalPasswordMapper)
			: base(logger,
			       mediator,
			       passwordRepository,
			       passwordModelValidator,
			       bolPasswordMapper,
			       dalPasswordMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8559182efccda0f041aea26062d55bd3</Hash>
</Codenesium>*/