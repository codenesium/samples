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
			List<BOStudio> items);
	}
}

/*<Codenesium>
    <Hash>132b6e665a76edf5486e9668fc476741</Hash>
</Codenesium>*/