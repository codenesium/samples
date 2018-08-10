using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLAddressMapper
	{
		BOAddress MapModelToBO(
			int addressID,
			ApiAddressRequestModel model);

		ApiAddressResponseModel MapBOToModel(
			BOAddress boAddress);

		List<ApiAddressResponseModel> MapBOToModel(
			List<BOAddress> items);
	}
}

/*<Codenesium>
    <Hash>7c0c43ea04be933e66619adba516396d</Hash>
</Codenesium>*/