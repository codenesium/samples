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
			List<BOStore> items);
	}
}

/*<Codenesium>
    <Hash>388c3f3bb9adbd3bd8e8a42dfd69cba4</Hash>
</Codenesium>*/