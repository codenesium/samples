using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALChainMapper
	{
		Chain MapModelToEntity(
			int id,
			ApiChainServerRequestModel model);

		ApiChainServerResponseModel MapEntityToModel(
			Chain item);

		List<ApiChainServerResponseModel> MapEntityToModel(
			List<Chain> items);
	}
}

/*<Codenesium>
    <Hash>2ea625e1764e7f9f044e28db5a0713e5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/