using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLAccountMapper
	{
		BOAccount MapModelToBO(
			string id,
			ApiAccountRequestModel model);

		ApiAccountResponseModel MapBOToModel(
			BOAccount boAccount);

		List<ApiAccountResponseModel> MapBOToModel(
			List<BOAccount> items);
	}
}

/*<Codenesium>
    <Hash>d1e249d39cc9b07152747962b14fbb9a</Hash>
</Codenesium>*/