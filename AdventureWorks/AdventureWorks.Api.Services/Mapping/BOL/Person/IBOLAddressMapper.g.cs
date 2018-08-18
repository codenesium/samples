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
    <Hash>5e180a96433277c12d3c0cba13776bae</Hash>
</Codenesium>*/