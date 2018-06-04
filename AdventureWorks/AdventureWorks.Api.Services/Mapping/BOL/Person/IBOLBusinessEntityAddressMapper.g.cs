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
			List<BOBusinessEntityAddress> bos);
	}
}

/*<Codenesium>
    <Hash>6c18f91e889cc18db5b72b35bc824ed8</Hash>
</Codenesium>*/