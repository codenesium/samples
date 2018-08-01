using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
			List<BOVendor> items);
	}
}

/*<Codenesium>
    <Hash>8daaa97c883f68ed89aeb01557c68039</Hash>
</Codenesium>*/