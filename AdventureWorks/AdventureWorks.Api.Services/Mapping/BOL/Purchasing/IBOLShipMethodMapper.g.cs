using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLShipMethodMapper
	{
		BOShipMethod MapModelToBO(
			int shipMethodID,
			ApiShipMethodRequestModel model);

		ApiShipMethodResponseModel MapBOToModel(
			BOShipMethod boShipMethod);

		List<ApiShipMethodResponseModel> MapBOToModel(
			List<BOShipMethod> bos);
	}
}

/*<Codenesium>
    <Hash>b76e0db89ceeaa44b2d643903c0ec3e2</Hash>
</Codenesium>*/