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
			IDALPasswordMapper dalPasswordMapper)
			: base(logger,
			       mediator,
			       passwordRepository,
			       passwordModelValidator,
			       dalPasswordMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>64209ac96d4661116d034ad84d0fac76</Hash>
</Codenesium>*/