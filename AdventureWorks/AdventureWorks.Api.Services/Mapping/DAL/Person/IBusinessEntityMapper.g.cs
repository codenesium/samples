using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALBusinessEntityMapper
	{
		BusinessEntity MapModelToEntity(
			int businessEntityID,
			ApiBusinessEntityServerRequestModel model);

		ApiBusinessEntityServerResponseModel MapEntityToModel(
			BusinessEntity item);

		List<ApiBusinessEntityServerResponseModel> MapEntityToModel(
			List<BusinessEntity> items);
	}
}

/*<Codenesium>
    <Hash>a44de20f31546446caca408dfef31897</Hash>
</Codenesium>*/