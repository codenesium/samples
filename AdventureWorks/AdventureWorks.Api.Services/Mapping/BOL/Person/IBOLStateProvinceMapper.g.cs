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
    <Hash>30399b9277dfdbe171657d682c4a1927</Hash>
</Codenesium>*/