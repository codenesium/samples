using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class CultureService : AbstractCultureService, ICultureService
	{
		public CultureService(
			ILogger<ICultureRepository> logger,
			ICultureRepository cultureRepository,
			IApiCultureServerRequestModelValidator cultureModelValidator,
			IBOLCultureMapper bolCultureMapper,
			IDALCultureMapper dalCultureMapper)
			: base(logger,
			       cultureRepository,
			       cultureModelValidator,
			       bolCultureMapper,
			       dalCultureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c39f5aa27b17eb2c5de3da0765399d32</Hash>
</Codenesium>*/