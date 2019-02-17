using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALIllustrationMapper
	{
		Illustration MapModelToEntity(
			int illustrationID,
			ApiIllustrationServerRequestModel model);

		ApiIllustrationServerResponseModel MapEntityToModel(
			Illustration item);

		List<ApiIllustrationServerResponseModel> MapEntityToModel(
			List<Illustration> items);
	}
}

/*<Codenesium>
    <Hash>95fc5d8980819cd7ddece25737e6263d</Hash>
</Codenesium>*/