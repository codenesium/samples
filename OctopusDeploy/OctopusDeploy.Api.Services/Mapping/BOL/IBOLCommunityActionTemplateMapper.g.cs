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
    <Hash>1bb21a6cfefdcce56d6ad1dc39aae827</Hash>
</Codenesium>*/