using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IBOLStudioMapper
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
    <Hash>2daa50efc9926ba8496d30b595b70499</Hash>
</Codenesium>*/