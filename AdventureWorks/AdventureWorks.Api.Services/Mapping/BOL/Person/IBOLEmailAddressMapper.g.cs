using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLEmailAddressMapper
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
    <Hash>77fa508c68782f6663aada2999b51c0e</Hash>
</Codenesium>*/