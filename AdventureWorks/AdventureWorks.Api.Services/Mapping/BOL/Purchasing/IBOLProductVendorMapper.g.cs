using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>e67befc35de3a3ef01d9b68f2ca590cf</Hash>
</Codenesium>*/