using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLEmailAddressMapper
	{
		BOEmailAddress MapModelToBO(
			int businessEntityID,
			ApiEmailAddressRequestModel model);

		ApiEmailAddressResponseModel MapBOToModel(
			BOEmailAddress boEmailAddress);

		List<ApiEmailAddressResponseModel> MapBOToModel(
			List<BOEmailAddress> bos);
	}
}

/*<Codenesium>
    <Hash>22463c092fab4f9c4e0df4bbbea088ed</Hash>
</Codenesium>*/