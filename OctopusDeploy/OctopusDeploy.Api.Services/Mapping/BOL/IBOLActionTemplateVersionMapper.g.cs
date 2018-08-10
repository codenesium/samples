using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLActionTemplateVersionMapper
	{
		BOActionTemplateVersion MapModelToBO(
			string id,
			ApiActionTemplateVersionRequestModel model);

		ApiActionTemplateVersionResponseModel MapBOToModel(
			BOActionTemplateVersion boActionTemplateVersion);

		List<ApiActionTemplateVersionResponseModel> MapBOToModel(
			List<BOActionTemplateVersion> items);
	}
}

/*<Codenesium>
    <Hash>e13e4c2ff56a242c3dd9eee020bf4edf</Hash>
</Codenesium>*/