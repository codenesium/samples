using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLVendorMapper
	{
		BOVendor MapModelToBO(
			int businessEntityID,
			ApiVendorServerRequestModel model);

		ApiVendorServerResponseModel MapBOToModel(
			BOVendor boVendor);

		List<ApiVendorServerResponseModel> MapBOToModel(
			List<BOVendor> items);
	}
}

/*<Codenesium>
    <Hash>886e6dd628a54e32f8718372ea8baf73</Hash>
</Codenesium>*/