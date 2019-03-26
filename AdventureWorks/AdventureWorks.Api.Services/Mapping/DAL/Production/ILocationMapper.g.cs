using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALLocationMapper
	{
		Location MapModelToEntity(
			short locationID,
			ApiLocationServerRequestModel model);

		ApiLocationServerResponseModel MapEntityToModel(
			Location item);

		List<ApiLocationServerResponseModel> MapEntityToModel(
			List<Location> items);
	}
}

/*<Codenesium>
    <Hash>31316b3bc8c287fcaac603623a12405f</Hash>
</Codenesium>*/