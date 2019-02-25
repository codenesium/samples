using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCultureMapper
	{
		Culture MapModelToEntity(
			string cultureID,
			ApiCultureServerRequestModel model);

		ApiCultureServerResponseModel MapEntityToModel(
			Culture item);

		List<ApiCultureServerResponseModel> MapEntityToModel(
			List<Culture> items);
	}
}

/*<Codenesium>
    <Hash>0661dc964709c942a128555b5b3a8b21</Hash>
</Codenesium>*/