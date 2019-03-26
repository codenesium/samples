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
			IDALBusinessEntityMapper dalBusinessEntityMapper,
			IDALPersonMapper dalPersonMapper)
			: base(logger,
			       mediator,
			       businessEntityRepository,
			       businessEntityModelValidator,
			       dalBusinessEntityMapper,
			       dalPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>841c6ba27315749840dfed80185e7e09</Hash>
</Codenesium>*/