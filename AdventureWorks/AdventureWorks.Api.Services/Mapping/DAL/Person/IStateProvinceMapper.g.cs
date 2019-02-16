using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALStateProvinceMapper
	{
		StateProvince MapModelToBO(
			int stateProvinceID,
			ApiStateProvinceServerRequestModel model);

		ApiStateProvinceServerResponseModel MapBOToModel(
			StateProvince item);

		List<ApiStateProvinceServerResponseModel> MapBOToModel(
			List<StateProvince> items);
	}
}

/*<Codenesium>
    <Hash>ae6bff2fa8a179427ac34ac698b10cfb</Hash>
</Codenesium>*/