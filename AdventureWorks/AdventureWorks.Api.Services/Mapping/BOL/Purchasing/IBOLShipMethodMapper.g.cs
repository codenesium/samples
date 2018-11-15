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
			ApiShipMethodServerRequestModel model);

		ApiShipMethodServerResponseModel MapBOToModel(
			BOShipMethod boShipMethod);

		List<ApiShipMethodServerResponseModel> MapBOToModel(
			List<BOShipMethod> items);
	}
}

/*<Codenesium>
    <Hash>79ee9d91bad06ba8d7f7474f1bdd5d26</Hash>
</Codenesium>*/