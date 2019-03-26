using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class CultureService : AbstractCultureService, ICultureService
	{
		public CultureService(
			ILogger<ICultureRepository> logger,
			IMediator mediator,
			ICultureRepository cultureRepository,
			IApiCultureServerRequestModelValidator cultureModelValidator,
			IDALCultureMapper dalCultureMapper)
			: base(logger,
			       mediator,
			       cultureRepository,
			       cultureModelValidator,
			       dalCultureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2ff0b7a9ed95eb7e1bbabc09730db3d9</Hash>
</Codenesium>*/