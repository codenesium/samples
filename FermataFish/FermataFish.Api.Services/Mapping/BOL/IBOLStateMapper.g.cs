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
			List<BOState> items);
	}
}

/*<Codenesium>
    <Hash>451055d43abdadd402f90175aad85064</Hash>
</Codenesium>*/