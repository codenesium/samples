using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductVendorMapper
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
    <Hash>0d6212e4f4cb9b616524caaec34ea99a</Hash>
</Codenesium>*/