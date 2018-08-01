using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
			List<BOShipMethod> items);
	}
}

/*<Codenesium>
    <Hash>3355806ef007bd983d298b7ce863a90d</Hash>
</Codenesium>*/