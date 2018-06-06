using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IBOLSpaceMapper
	{
		BOSpace MapModelToBO(
			int id,
			ApiSpaceRequestModel model);

		ApiSpaceResponseModel MapBOToModel(
			BOSpace boSpace);

		List<ApiSpaceResponseModel> MapBOToModel(
			List<BOSpace> items);
	}
}

/*<Codenesium>
    <Hash>45fb8ebc1e2a32c8af6a481285b8d98c</Hash>
</Codenesium>*/