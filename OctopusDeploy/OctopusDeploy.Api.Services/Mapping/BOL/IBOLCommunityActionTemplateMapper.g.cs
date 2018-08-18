using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLCommunityActionTemplateMapper
	{
		BOCommunityActionTemplate MapModelToBO(
			string id,
			ApiCommunityActionTemplateRequestModel model);

		ApiCommunityActionTemplateResponseModel MapBOToModel(
			BOCommunityActionTemplate boCommunityActionTemplate);

		List<ApiCommunityActionTemplateResponseModel> MapBOToModel(
			List<BOCommunityActionTemplate> items);
	}
}

/*<Codenesium>
    <Hash>c4d1c20ef9e2378d535089872a165e64</Hash>
</Codenesium>*/