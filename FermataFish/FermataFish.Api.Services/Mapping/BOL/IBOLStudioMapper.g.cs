using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
			List<BOStudio> bos);
	}
}

/*<Codenesium>
    <Hash>29678f3189f662d6d398769a5ec4343b</Hash>
</Codenesium>*/