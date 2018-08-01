using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
			List<BOStore> items);
	}
}

/*<Codenesium>
    <Hash>3ba88dcb3041312fdc06c4cf8695d5b4</Hash>
</Codenesium>*/