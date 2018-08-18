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
    <Hash>d14e90e0643f01551585c143f408dd80</Hash>
</Codenesium>*/