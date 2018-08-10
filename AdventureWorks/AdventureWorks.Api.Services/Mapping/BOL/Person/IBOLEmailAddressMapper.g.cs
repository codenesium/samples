using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLEmailAddressMapper
	{
		BOEmailAddress MapModelToBO(
			int businessEntityID,
			ApiEmailAddressRequestModel model);

		ApiEmailAddressResponseModel MapBOToModel(
			BOEmailAddress boEmailAddress);

		List<ApiEmailAddressResponseModel> MapBOToModel(
			List<BOEmailAddress> items);
	}
}

/*<Codenesium>
    <Hash>94840ff610421afc65c74e7885c93e5f</Hash>
</Codenesium>*/