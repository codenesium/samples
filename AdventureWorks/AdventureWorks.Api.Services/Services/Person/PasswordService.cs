using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class PasswordService : AbstractPasswordService, IPasswordService
	{
		public PasswordService(
			ILogger<IPasswordRepository> logger,
			IPasswordRepository passwordRepository,
			IApiPasswordServerRequestModelValidator passwordModelValidator,
			IBOLPasswordMapper bolPasswordMapper,
			IDALPasswordMapper dalPasswordMapper)
			: base(logger,
			       passwordRepository,
			       passwordModelValidator,
			       bolPasswordMapper,
			       dalPasswordMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>05193cb671a47fd18d440ae08de904a4</Hash>
</Codenesium>*/