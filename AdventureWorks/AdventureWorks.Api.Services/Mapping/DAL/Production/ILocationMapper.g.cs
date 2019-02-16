using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALLocationMapper
	{
		Location MapModelToBO(
			short locationID,
			ApiLocationServerRequestModel model);

		ApiLocationServerResponseModel MapBOToModel(
			Location item);

		List<ApiLocationServerResponseModel> MapBOToModel(
			List<Location> items);
	}
}

/*<Codenesium>
    <Hash>19cc6a1370735059b4bc982deb72bc0b</Hash>
</Codenesium>*/