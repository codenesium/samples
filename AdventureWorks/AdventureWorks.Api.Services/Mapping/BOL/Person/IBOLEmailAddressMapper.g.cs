using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>c060f92b887ae629a4a91cab9025f918</Hash>
</Codenesium>*/