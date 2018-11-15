using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLAddressTypeMapper
	{
		BOAddressType MapModelToBO(
			int addressTypeID,
			ApiAddressTypeServerRequestModel model);

		ApiAddressTypeServerResponseModel MapBOToModel(
			BOAddressType boAddressType);

		List<ApiAddressTypeServerResponseModel> MapBOToModel(
			List<BOAddressType> items);
	}
}

/*<Codenesium>
    <Hash>e15cdf71c3018db5004b9a7abe6811bb</Hash>
</Codenesium>*/