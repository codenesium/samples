using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALBusinessEntityMapper
	{
		BusinessEntity MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityServerRequestModel model);

		ApiBusinessEntityServerResponseModel MapBOToModel(
			BusinessEntity item);

		List<ApiBusinessEntityServerResponseModel> MapBOToModel(
			List<BusinessEntity> items);
	}
}

/*<Codenesium>
    <Hash>f752814020653f469694b31ac49bd648</Hash>
</Codenesium>*/