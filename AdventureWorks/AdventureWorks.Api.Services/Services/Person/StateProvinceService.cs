using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class StateProvinceService : AbstractStateProvinceService, IStateProvinceService
	{
		public StateProvinceService(
			ILogger<IStateProvinceRepository> logger,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceRequestModelValidator stateProvinceModelValidator,
			IBOLStateProvinceMapper bolstateProvinceMapper,
			IDALStateProvinceMapper dalstateProvinceMapper,
			IBOLAddressMapper bolAddressMapper,
			IDALAddressMapper dalAddressMapper
			)
			: base(logger,
			       stateProvinceRepository,
			       stateProvinceModelValidator,
			       bolstateProvinceMapper,
			       dalstateProvinceMapper,
			       bolAddressMapper,
			       dalAddressMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>eeaaf6866f52318ffbe4c41b998be664</Hash>
</Codenesium>*/