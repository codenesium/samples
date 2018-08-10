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
    <Hash>a022cca0def2b1279fb4db72a43d790d</Hash>
</Codenesium>*/