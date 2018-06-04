using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLVendorMapper
	{
		BOVendor MapModelToBO(
			int businessEntityID,
			ApiVendorRequestModel model);

		ApiVendorResponseModel MapBOToModel(
			BOVendor boVendor);

		List<ApiVendorResponseModel> MapBOToModel(
			List<BOVendor> bos);
	}
}

/*<Codenesium>
    <Hash>35bcedd8ddd09520322a8c4cc298135c</Hash>
</Codenesium>*/