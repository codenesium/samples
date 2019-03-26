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
			IDALStateProvinceMapper dalStateProvinceMapper,
			IDALAddressMapper dalAddressMapper)
			: base(logger,
			       mediator,
			       stateProvinceRepository,
			       stateProvinceModelValidator,
			       dalStateProvinceMapper,
			       dalAddressMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4ee60c60c7b70bdcbb528afece574c67</Hash>
</Codenesium>*/