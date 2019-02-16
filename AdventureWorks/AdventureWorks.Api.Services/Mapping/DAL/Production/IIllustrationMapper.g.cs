using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALIllustrationMapper
	{
		Illustration MapModelToBO(
			int illustrationID,
			ApiIllustrationServerRequestModel model);

		ApiIllustrationServerResponseModel MapBOToModel(
			Illustration item);

		List<ApiIllustrationServerResponseModel> MapBOToModel(
			List<Illustration> items);
	}
}

/*<Codenesium>
    <Hash>07a2986e5c41e0cef97fc6763fdb807c</Hash>
</Codenesium>*/