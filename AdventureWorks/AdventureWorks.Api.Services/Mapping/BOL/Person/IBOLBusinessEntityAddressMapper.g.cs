using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLBusinessEntityAddressMapper
	{
		BOBusinessEntityAddress MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel model);

		ApiBusinessEntityAddressResponseModel MapBOToModel(
			BOBusinessEntityAddress boBusinessEntityAddress);

		List<ApiBusinessEntityAddressResponseModel> MapBOToModel(
			List<BOBusinessEntityAddress> items);
	}
}

/*<Codenesium>
    <Hash>f0e02111cf41295f5f87b718ab514bd3</Hash>
</Codenesium>*/