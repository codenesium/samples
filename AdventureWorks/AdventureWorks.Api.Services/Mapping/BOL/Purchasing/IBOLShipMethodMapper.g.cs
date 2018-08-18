using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLShipMethodMapper
	{
		BOShipMethod MapModelToBO(
			int shipMethodID,
			ApiShipMethodRequestModel model);

		ApiShipMethodResponseModel MapBOToModel(
			BOShipMethod boShipMethod);

		List<ApiShipMethodResponseModel> MapBOToModel(
			List<BOShipMethod> items);
	}
}

/*<Codenesium>
    <Hash>fd13bec54e0bf0553e0952eb53908339</Hash>
</Codenesium>*/