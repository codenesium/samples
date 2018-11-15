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
			ApiStateProvinceServerRequestModel model);

		ApiStateProvinceServerResponseModel MapBOToModel(
			BOStateProvince boStateProvince);

		List<ApiStateProvinceServerResponseModel> MapBOToModel(
			List<BOStateProvince> items);
	}
}

/*<Codenesium>
    <Hash>0994164b1598f0971c9f1989f28f29ce</Hash>
</Codenesium>*/