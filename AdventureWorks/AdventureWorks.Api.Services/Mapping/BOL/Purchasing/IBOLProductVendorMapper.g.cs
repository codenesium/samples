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
			List<BOProductVendor> bos);
	}
}

/*<Codenesium>
    <Hash>d1f7d1ba70316ecb6c8e71e47f635fe2</Hash>
</Codenesium>*/