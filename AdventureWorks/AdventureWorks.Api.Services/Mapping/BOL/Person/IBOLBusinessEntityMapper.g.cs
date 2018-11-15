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
			ApiBusinessEntityServerRequestModel model);

		ApiBusinessEntityServerResponseModel MapBOToModel(
			BOBusinessEntity boBusinessEntity);

		List<ApiBusinessEntityServerResponseModel> MapBOToModel(
			List<BOBusinessEntity> items);
	}
}

/*<Codenesium>
    <Hash>8e8129f94200818129ae8d679bce0df1</Hash>
</Codenesium>*/