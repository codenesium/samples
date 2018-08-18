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
    <Hash>416751046dd1d7c6fd1be2abe85ae8fa</Hash>
</Codenesium>*/