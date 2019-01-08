using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLTableMapper
	{
		BOTable MapModelToBO(
			int id,
			ApiTableServerRequestModel model);

		ApiTableServerResponseModel MapBOToModel(
			BOTable boTable);

		List<ApiTableServerResponseModel> MapBOToModel(
			List<BOTable> items);
	}
}

/*<Codenesium>
    <Hash>3bd35d7258ca732a57548a472b559218</Hash>
</Codenesium>*/