using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALAddressMapper
	{
		Address MapModelToBO(
			int addressID,
			ApiAddressServerRequestModel model);

		ApiAddressServerResponseModel MapBOToModel(
			Address item);

		List<ApiAddressServerResponseModel> MapBOToModel(
			List<Address> items);
	}
}

/*<Codenesium>
    <Hash>a35829c15c5b789fb3e8d3b3d63404df</Hash>
</Codenesium>*/