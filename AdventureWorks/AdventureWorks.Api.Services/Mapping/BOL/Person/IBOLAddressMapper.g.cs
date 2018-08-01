using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLAddressMapper
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
    <Hash>c09711f87f957c9307cf3033bc1dbfa9</Hash>
</Codenesium>*/