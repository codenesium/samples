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
			IBOLCultureMapper bolCultureMapper,
			IDALCultureMapper dalCultureMapper)
			: base(logger,
			       mediator,
			       cultureRepository,
			       cultureModelValidator,
			       bolCultureMapper,
			       dalCultureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c0eb501489ff9d31f9385b97cbd83ba4</Hash>
</Codenesium>*/