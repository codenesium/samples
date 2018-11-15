using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class StateProvinceService : AbstractStateProvinceService, IStateProvinceService
	{
		public StateProvinceService(
			ILogger<IStateProvinceRepository> logger,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceServerRequestModelValidator stateProvinceModelValidator,
			IBOLStateProvinceMapper bolStateProvinceMapper,
			IDALStateProvinceMapper dalStateProvinceMapper,
			IBOLAddressMapper bolAddressMapper,
			IDALAddressMapper dalAddressMapper)
			: base(logger,
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
    <Hash>86175aa05e43cfcf39ab7e9e1fafc3ad</Hash>
</Codenesium>*/