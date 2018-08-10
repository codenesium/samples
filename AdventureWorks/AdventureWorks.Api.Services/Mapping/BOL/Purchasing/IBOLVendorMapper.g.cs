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
    <Hash>3ef70a7861aec6120d85111dd4dd12e9</Hash>
</Codenesium>*/