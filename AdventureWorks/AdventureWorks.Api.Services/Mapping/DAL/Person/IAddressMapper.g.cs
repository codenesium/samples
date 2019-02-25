using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALAddressMapper
	{
		Address MapModelToEntity(
			int addressID,
			ApiAddressServerRequestModel model);

		ApiAddressServerResponseModel MapEntityToModel(
			Address item);

		List<ApiAddressServerResponseModel> MapEntityToModel(
			List<Address> items);
	}
}

/*<Codenesium>
    <Hash>5a5a76720a2bc84ed2ec804ae0728b6c</Hash>
</Codenesium>*/