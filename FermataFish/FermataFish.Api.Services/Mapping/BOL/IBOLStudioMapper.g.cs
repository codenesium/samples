using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLStudioMapper
	{
		BOStudio MapModelToBO(
			int id,
			ApiStudioRequestModel model);

		ApiStudioResponseModel MapBOToModel(
			BOStudio boStudio);

		List<ApiStudioResponseModel> MapBOToModel(
			List<BOStudio> items);
	}
}

/*<Codenesium>
    <Hash>5d82fbd2f13b6d9d1d735d2886ab66bf</Hash>
</Codenesium>*/