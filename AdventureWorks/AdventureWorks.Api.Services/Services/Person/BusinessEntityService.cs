using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class BusinessEntityService : AbstractBusinessEntityService, IBusinessEntityService
	{
		public BusinessEntityService(
			ILogger<IBusinessEntityRepository> logger,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityServerRequestModelValidator businessEntityModelValidator,
			IBOLBusinessEntityMapper bolBusinessEntityMapper,
			IDALBusinessEntityMapper dalBusinessEntityMapper,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper)
			: base(logger,
			       businessEntityRepository,
			       businessEntityModelValidator,
			       bolBusinessEntityMapper,
			       dalBusinessEntityMapper,
			       bolPersonMapper,
			       dalPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a99d92b747e784cc1ad07feece119c9c</Hash>
</Codenesium>*/