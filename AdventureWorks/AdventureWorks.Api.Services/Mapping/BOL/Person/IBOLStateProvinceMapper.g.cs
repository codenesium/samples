using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLStateProvinceMapper
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
    <Hash>c9e82d6a0e67b486d5955e6c6b472ab0</Hash>
</Codenesium>*/