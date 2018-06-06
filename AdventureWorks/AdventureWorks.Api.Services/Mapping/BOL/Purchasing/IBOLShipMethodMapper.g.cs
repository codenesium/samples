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
			List<BOShipMethod> items);
	}
}

/*<Codenesium>
    <Hash>640ea25a17c54b63a00fa662d4bedc9a</Hash>
</Codenesium>*/