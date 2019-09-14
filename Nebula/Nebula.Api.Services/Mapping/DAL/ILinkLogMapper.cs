using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALLinkLogMapper
	{
		LinkLog MapModelToEntity(
			int id,
			ApiLinkLogServerRequestModel model);

		ApiLinkLogServerResponseModel MapEntityToModel(
			LinkLog item);

		List<ApiLinkLogServerResponseModel> MapEntityToModel(
			List<LinkLog> items);
	}
}

/*<Codenesium>
    <Hash>d8fb26f9878633e9d87afdeb4c6b7698</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/