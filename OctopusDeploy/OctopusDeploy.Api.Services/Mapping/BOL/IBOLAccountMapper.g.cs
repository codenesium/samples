using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLAccountMapper
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
    <Hash>3618af563477a015156b97954ecf323e</Hash>
</Codenesium>*/