using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
			List<BOState> items);
	}
}

/*<Codenesium>
    <Hash>1012ac99b9f4e28e229e0204e34f35a8</Hash>
</Codenesium>*/