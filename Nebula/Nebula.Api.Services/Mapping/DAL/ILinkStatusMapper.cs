using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALLinkStatusMapper
	{
		LinkStatus MapModelToEntity(
			int id,
			ApiLinkStatusServerRequestModel model);

		ApiLinkStatusServerResponseModel MapEntityToModel(
			LinkStatus item);

		List<ApiLinkStatusServerResponseModel> MapEntityToModel(
			List<LinkStatus> items);
	}
}

/*<Codenesium>
    <Hash>fcef13090326993555d7965a79149075</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/