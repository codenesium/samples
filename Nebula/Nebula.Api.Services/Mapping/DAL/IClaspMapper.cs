using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALClaspMapper
	{
		Clasp MapModelToEntity(
			int id,
			ApiClaspServerRequestModel model);

		ApiClaspServerResponseModel MapEntityToModel(
			Clasp item);

		List<ApiClaspServerResponseModel> MapEntityToModel(
			List<Clasp> items);
	}
}

/*<Codenesium>
    <Hash>04e94d90850602dea03c79c7fe32a1a7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/