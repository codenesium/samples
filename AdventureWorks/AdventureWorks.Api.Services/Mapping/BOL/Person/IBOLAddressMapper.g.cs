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
			List<BOAddress> bos);
	}
}

/*<Codenesium>
    <Hash>49cf97ea17fcef7edd59b336c7d67e8d</Hash>
</Codenesium>*/