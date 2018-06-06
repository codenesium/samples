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
			List<BOVendor> items);
	}
}

/*<Codenesium>
    <Hash>aef2c33219a71a5830d5bd19d274feb2</Hash>
</Codenesium>*/