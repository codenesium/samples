using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLBusinessEntityMapper
	{
		BOBusinessEntity MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityRequestModel model);

		ApiBusinessEntityResponseModel MapBOToModel(
			BOBusinessEntity boBusinessEntity);

		List<ApiBusinessEntityResponseModel> MapBOToModel(
			List<BOBusinessEntity> items);
	}
}

/*<Codenesium>
    <Hash>fbfb5a990ca6620d23fb0caa81a1fa8f</Hash>
</Codenesium>*/