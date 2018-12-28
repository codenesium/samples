using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class StateProvinceService : AbstractStateProvinceService, IStateProvinceService
	{
		public StateProvinceService(
			ILogger<IStateProvinceRepository> logger,
			IMediator mediator,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceServerRequestModelValidator stateProvinceModelValidator,
			IBOLStateProvinceMapper bolStateProvinceMapper,
			IDALStateProvinceMapper dalStateProvinceMapper,
			IBOLAddressMapper bolAddressMapper,
			IDALAddressMapper dalAddressMapper)
			: base(logger,
			       mediator,
			       stateProvinceRepository,
			       stateProvinceModelValidator,
			       bolStateProvinceMapper,
			       dalStateProvinceMapper,
			       bolAddressMapper,
			       dalAddressMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>08b42eb8ff9fcdaf70472cceb413ef1c</Hash>
</Codenesium>*/