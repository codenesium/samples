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
			List<BOSpace> bos);
	}
}

/*<Codenesium>
    <Hash>2b3bfebf1c8840fdb3da788efdca245a</Hash>
</Codenesium>*/