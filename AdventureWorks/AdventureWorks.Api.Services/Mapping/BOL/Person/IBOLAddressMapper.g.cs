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
			ApiAddressServerRequestModel model);

		ApiAddressServerResponseModel MapBOToModel(
			BOAddress boAddress);

		List<ApiAddressServerResponseModel> MapBOToModel(
			List<BOAddress> items);
	}
}

/*<Codenesium>
    <Hash>4bbd6a90ce165872953809934afcc044</Hash>
</Codenesium>*/