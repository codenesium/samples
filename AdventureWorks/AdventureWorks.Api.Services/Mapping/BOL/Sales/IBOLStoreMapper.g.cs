using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLStoreMapper
	{
		BOStore MapModelToBO(
			int businessEntityID,
			ApiStoreRequestModel model);

		ApiStoreResponseModel MapBOToModel(
			BOStore boStore);

		List<ApiStoreResponseModel> MapBOToModel(
			List<BOStore> bos);
	}
}

/*<Codenesium>
    <Hash>e4de2812f60cc0c0946e5275f7ae77bf</Hash>
</Codenesium>*/