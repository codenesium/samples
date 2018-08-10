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
    <Hash>3cc751557db21602c85c79765ac549f7</Hash>
</Codenesium>*/