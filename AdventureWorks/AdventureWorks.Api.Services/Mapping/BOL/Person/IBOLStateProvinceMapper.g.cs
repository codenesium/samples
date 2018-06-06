using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>e0d3bc19b0f7ffd14a355f8c1b3254de</Hash>
</Codenesium>*/