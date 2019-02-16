using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALShipMethodMapper
	{
		ShipMethod MapModelToBO(
			int shipMethodID,
			ApiShipMethodServerRequestModel model);

		ApiShipMethodServerResponseModel MapBOToModel(
			ShipMethod item);

		List<ApiShipMethodServerResponseModel> MapBOToModel(
			List<ShipMethod> items);
	}
}

/*<Codenesium>
    <Hash>2f859a581d1c056a2bd5573e25b15bac</Hash>
</Codenesium>*/