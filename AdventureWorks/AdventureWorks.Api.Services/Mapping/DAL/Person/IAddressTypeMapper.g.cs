using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALAddressTypeMapper
	{
		AddressType MapModelToBO(
			int addressTypeID,
			ApiAddressTypeServerRequestModel model);

		ApiAddressTypeServerResponseModel MapBOToModel(
			AddressType item);

		List<ApiAddressTypeServerResponseModel> MapBOToModel(
			List<AddressType> items);
	}
}

/*<Codenesium>
    <Hash>a1bfcec9c7b218e1386235870a9bf78c</Hash>
</Codenesium>*/