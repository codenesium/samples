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
			ApiAddressTypeRequestModel model);

		ApiAddressTypeResponseModel MapBOToModel(
			BOAddressType boAddressType);

		List<ApiAddressTypeResponseModel> MapBOToModel(
			List<BOAddressType> items);
	}
}

/*<Codenesium>
    <Hash>374e880cf9ed64a92fc51b1a01f0dd42</Hash>
</Codenesium>*/