using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALRowVersionCheckMapper
	{
		RowVersionCheck MapModelToEntity(
			int id,
			ApiRowVersionCheckServerRequestModel model);

		ApiRowVersionCheckServerResponseModel MapEntityToModel(
			RowVersionCheck item);

		List<ApiRowVersionCheckServerResponseModel> MapEntityToModel(
			List<RowVersionCheck> items);
	}
}

/*<Codenesium>
    <Hash>e8a5e051e49d55819a55c877851b038f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/