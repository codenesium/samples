using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLTagSetMapper
	{
		BOTagSet MapModelToBO(
			string id,
			ApiTagSetRequestModel model);

		ApiTagSetResponseModel MapBOToModel(
			BOTagSet boTagSet);

		List<ApiTagSetResponseModel> MapBOToModel(
			List<BOTagSet> items);
	}
}

/*<Codenesium>
    <Hash>8c70899e6d79df36e53077c14783215b</Hash>
</Codenesium>*/