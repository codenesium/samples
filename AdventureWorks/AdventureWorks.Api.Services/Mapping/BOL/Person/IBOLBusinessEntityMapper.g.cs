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
    <Hash>a0dc2b555b0091157dcd7537bf86efa8</Hash>
</Codenesium>*/