using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IBOLStateMapper
	{
		BOState MapModelToBO(
			int id,
			ApiStateRequestModel model);

		ApiStateResponseModel MapBOToModel(
			BOState boState);

		List<ApiStateResponseModel> MapBOToModel(
			List<BOState> bos);
	}
}

/*<Codenesium>
    <Hash>322e9eb7b34ff6e062831e758c2b5046</Hash>
</Codenesium>*/