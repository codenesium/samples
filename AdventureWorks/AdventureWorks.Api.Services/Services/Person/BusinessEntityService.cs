using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class BusinessEntityService : AbstractBusinessEntityService, IBusinessEntityService
	{
		public BusinessEntityService(
			ILogger<IBusinessEntityRepository> logger,
			IMediator mediator,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityServerRequestModelValidator businessEntityModelValidator,
			IBOLBusinessEntityMapper bolBusinessEntityMapper,
			IDALBusinessEntityMapper dalBusinessEntityMapper,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper)
			: base(logger,
			       mediator,
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
    <Hash>09675b5abd5d902d93442e4fee531f37</Hash>
</Codenesium>*/