using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLAddressMapper
	{
		BOAddress MapModelToBO(
			int addressID,
			ApiAddressRequestModel model);

		ApiAddressResponseModel MapBOToModel(
			BOAddress boAddress);

		List<ApiAddressResponseModel> MapBOToModel(
			List<BOAddress> items);
	}
}

/*<Codenesium>
    <Hash>daa24836cc2ca09c64d785e213d36f49</Hash>
</Codenesium>*/