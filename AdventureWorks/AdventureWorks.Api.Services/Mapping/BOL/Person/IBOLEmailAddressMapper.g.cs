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
    <Hash>4b6b69611bdbbe33e76adadba0c7824e</Hash>
</Codenesium>*/