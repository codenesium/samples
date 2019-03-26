using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALAddressTypeMapper
	{
		AddressType MapModelToEntity(
			int addressTypeID,
			ApiAddressTypeServerRequestModel model);

		ApiAddressTypeServerResponseModel MapEntityToModel(
			AddressType item);

		List<ApiAddressTypeServerResponseModel> MapEntityToModel(
			List<AddressType> items);
	}
}

/*<Codenesium>
    <Hash>9488a3c70a53ddd79ddc246af53dc461</Hash>
</Codenesium>*/