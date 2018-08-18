using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLStateProvinceMapper
	{
		BOStateProvince MapModelToBO(
			int stateProvinceID,
			ApiStateProvinceRequestModel model);

		ApiStateProvinceResponseModel MapBOToModel(
			BOStateProvince boStateProvince);

		List<ApiStateProvinceResponseModel> MapBOToModel(
			List<BOStateProvince> items);
	}
}

/*<Codenesium>
    <Hash>fb2a0c0c1dfbb64348220c21d4e40f77</Hash>
</Codenesium>*/