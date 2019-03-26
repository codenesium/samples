using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALStateProvinceMapper
	{
		StateProvince MapModelToEntity(
			int stateProvinceID,
			ApiStateProvinceServerRequestModel model);

		ApiStateProvinceServerResponseModel MapEntityToModel(
			StateProvince item);

		List<ApiStateProvinceServerResponseModel> MapEntityToModel(
			List<StateProvince> items);
	}
}

/*<Codenesium>
    <Hash>64d628a814ddfde639e0922acfeb807d</Hash>
</Codenesium>*/