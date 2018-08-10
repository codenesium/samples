using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLBusinessEntityAddressMapper
	{
		BOBusinessEntityAddress MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel model);

		ApiBusinessEntityAddressResponseModel MapBOToModel(
			BOBusinessEntityAddress boBusinessEntityAddress);

		List<ApiBusinessEntityAddressResponseModel> MapBOToModel(
			List<BOBusinessEntityAddress> items);
	}
}

/*<Codenesium>
    <Hash>bfba4b4b7ed73369010879bdbbb0573c</Hash>
</Codenesium>*/