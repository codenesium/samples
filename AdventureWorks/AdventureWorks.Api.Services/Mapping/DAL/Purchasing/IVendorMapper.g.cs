using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALVendorMapper
	{
		Vendor MapModelToBO(
			int businessEntityID,
			ApiVendorServerRequestModel model);

		ApiVendorServerResponseModel MapBOToModel(
			Vendor item);

		List<ApiVendorServerResponseModel> MapBOToModel(
			List<Vendor> items);
	}
}

/*<Codenesium>
    <Hash>18e8bf780511685120f5983932011a2a</Hash>
</Codenesium>*/