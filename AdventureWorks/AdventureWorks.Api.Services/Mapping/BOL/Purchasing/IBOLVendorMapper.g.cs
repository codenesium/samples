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
			ApiVendorRequestModel model);

		ApiVendorResponseModel MapBOToModel(
			BOVendor boVendor);

		List<ApiVendorResponseModel> MapBOToModel(
			List<BOVendor> items);
	}
}

/*<Codenesium>
    <Hash>290604c99eda117fc81b1fa76ae8ddf8</Hash>
</Codenesium>*/