using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductVendorMapper
	{
		BOProductVendor MapModelToBO(
			int productID,
			ApiProductVendorRequestModel model);

		ApiProductVendorResponseModel MapBOToModel(
			BOProductVendor boProductVendor);

		List<ApiProductVendorResponseModel> MapBOToModel(
			List<BOProductVendor> items);
	}
}

/*<Codenesium>
    <Hash>d828cd4d159d9f5f8207c36e931f49fc</Hash>
</Codenesium>*/