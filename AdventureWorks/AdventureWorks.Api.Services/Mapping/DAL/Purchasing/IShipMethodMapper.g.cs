using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALShipMethodMapper
	{
		ShipMethod MapModelToEntity(
			int shipMethodID,
			ApiShipMethodServerRequestModel model);

		ApiShipMethodServerResponseModel MapEntityToModel(
			ShipMethod item);

		List<ApiShipMethodServerResponseModel> MapEntityToModel(
			List<ShipMethod> items);
	}
}

/*<Codenesium>
    <Hash>223a6b0c61b41a979dc4828f7a2d1afc</Hash>
</Codenesium>*/