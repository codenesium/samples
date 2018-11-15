using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLEmployeeMapper
	{
		BOEmployee MapModelToBO(
			int businessEntityID,
			ApiEmployeeServerRequestModel model);

		ApiEmployeeServerResponseModel MapBOToModel(
			BOEmployee boEmployee);

		List<ApiEmployeeServerResponseModel> MapBOToModel(
			List<BOEmployee> items);
	}
}

/*<Codenesium>
    <Hash>17151cbd70c163a6c3310222ee3701fc</Hash>
</Codenesium>*/