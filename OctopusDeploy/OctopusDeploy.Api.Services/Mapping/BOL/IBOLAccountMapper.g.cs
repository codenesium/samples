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
    <Hash>1ba5fc991748b4b68a9587dac0503c6c</Hash>
</Codenesium>*/