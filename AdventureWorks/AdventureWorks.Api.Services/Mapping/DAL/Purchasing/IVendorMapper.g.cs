using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALVendorMapper
	{
		Vendor MapModelToEntity(
			int businessEntityID,
			ApiVendorServerRequestModel model);

		ApiVendorServerResponseModel MapEntityToModel(
			Vendor item);

		List<ApiVendorServerResponseModel> MapEntityToModel(
			List<Vendor> items);
	}
}

/*<Codenesium>
    <Hash>43e812a9aa8e2d95380fadcf7a638b42</Hash>
</Codenesium>*/