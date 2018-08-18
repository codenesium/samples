using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLPasswordMapper
	{
		BOPassword MapModelToBO(
			int businessEntityID,
			ApiPasswordRequestModel model);

		ApiPasswordResponseModel MapBOToModel(
			BOPassword boPassword);

		List<ApiPasswordResponseModel> MapBOToModel(
			List<BOPassword> items);
	}
}

/*<Codenesium>
    <Hash>340d5b01b04400c595f3db52fc8b5538</Hash>
</Codenesium>*/